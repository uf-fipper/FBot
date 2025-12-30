using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using FBot.OneBotV11.Events;
using FBot.OneBotV11.Events.Messages;
using FBot.OneBotV11.Events.Metas;
using FBot.OneBotV11.Events.Notices;
using FBot.OneBotV11.Events.Requests;
using Microsoft.Extensions.Options;

namespace FBot.OneBotV11;

public class OneBotV11Adapter
{
    private FDriver Driver { get; set; }

    private IOptions<OneBotV11Config> OneBotV11Config { get; set; }

    private ILogger<OneBotV11Adapter>? Logger { get; set; }

    public OneBotV11Adapter(
        FDriver driver,
        IOptions<OneBotV11Config> oneBotV11Config,
        ILogger<OneBotV11Adapter> logger
    )
    {
        Driver = driver;
        OneBotV11Config = oneBotV11Config;
        Logger = logger;
    }

    public OneBotV11Adapter(FDriver driver, IOptions<OneBotV11Config> oneBotV11Config)
    {
        Driver = driver;
        OneBotV11Config = oneBotV11Config;
    }

    protected virtual IOneBotV11Bot CreateBot(long id, HttpServerConfig serverConfig)
    {
        return new OneBotV11HttpBot(this, id, serverConfig);
    }

    protected virtual IOneBotV11Bot CreateBot(long id, WebSocket webSocket)
    {
        return new OneBotV11WebSocketBot(this, id, webSocket);
    }

    public void Init(IEndpointRouteBuilder app, CancellationToken cancellationToken)
    {
        foreach (var botConfig in OneBotV11Config.Value.Bots)
        {
            InitBot(botConfig, app, cancellationToken);
        }
    }

    internal readonly Dictionary<Guid, JsonElement?> WebSocketResponses = [];

    private void InitBot(
        OneBotV11BotConfig botConfig,
        IEndpointRouteBuilder app,
        CancellationToken cancellationToken
    )
    {
        if (botConfig.WebSocketServerConfig is not null)
        {
            Task.Run(
                async () =>
                    await InitWebSocketServerAsync(
                        botConfig.WebSocketServerConfig,
                        cancellationToken
                    ),
                cancellationToken
            );
        }
        if (botConfig.WebSocketClientConfig is not null)
        {
            InitWebSocketClient(botConfig.WebSocketClientConfig, app, cancellationToken);
        }
        if (botConfig.HttpConfig is not null)
        {
            InitWebHook(botConfig.HttpConfig, app, cancellationToken);
        }
    }

    private async Task InitWebSocketServerAsync(
        WebSocketServerConfig config,
        CancellationToken cancellationToken
    )
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            using var webSocket = new ClientWebSocket();
            try
            {
                if (!string.IsNullOrEmpty(config.Token))
                {
                    webSocket.Options.SetRequestHeader("Authorization", $"Bearer {config.Token}");
                }

                await webSocket.ConnectAsync(new Uri(config.Url), cancellationToken);
                while (!cancellationToken.IsCancellationRequested)
                {
                    await HandleWebSocketResultAsync(webSocket, cancellationToken);
                }
            }
            catch (Exception e)
            {
                Logger?.LogError(e, "");
            }

            await Task.Delay(3000, cancellationToken);
        }
    }

    private void InitWebSocketClient(
        WebSocketClientConfig config,
        IEndpointRouteBuilder app,
        CancellationToken cancellationToken
    )
    {
        app.Map(
            config.Url,
            async (context) =>
            {
                if (!context.WebSockets.IsWebSocketRequest)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    return;
                }

                using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                try
                {
                    while (true)
                    {
                        await HandleWebSocketResultAsync(webSocket, cancellationToken);
                    }
                }
                catch (WebSocketException) { }
                catch (Exception e)
                {
                    Logger?.LogError(e, "");
                }
            }
        );
    }

    private async Task HandleWebSocketResultAsync(
        WebSocket webSocket,
        CancellationToken cancellationToken
    )
    {
        var jsonElement = await webSocket.ReceiveAsJsonAsync<JsonElement>();
        // 也有可能是请求接口返回
        if (!jsonElement.TryGetProperty("post_type", out _))
        {
            var guid = jsonElement.GetProperty("echo").GetGuid();
            if (WebSocketResponses.TryGetValue(guid, out var value))
            {
                if (value is not null)
                {
                    // 重复响应
                    return;
                }
                WebSocketResponses[guid] = jsonElement;
            }

            return;
        }
        var @event = GetEvent(jsonElement);
        if (@event is HeartbeatEvent or LifecycleEvent)
        {
            return;
        }
        var bot = CreateBot(@event.SelfId, webSocket);
        await Driver.RunEventMethodsAsync(bot, @event, cancellationToken);
    }

    private void InitWebHook(
        HttpConfig config,
        IEndpointRouteBuilder app,
        CancellationToken cancellationToken
    )
    {
        app.MapPost(
            config.HttpClientConfig.Url,
            async (context) =>
            {
                if (!await VerifySignature(context, config.HttpClientConfig.Token))
                {
                    context.Response.StatusCode = 401;
                    return;
                }
                var request = context.Request;
                var jsonElement = await request.ReadFromJsonAsync<JsonElement>(cancellationToken);
                var @event = GetEvent(jsonElement);
                var bot = CreateBot(@event.SelfId, config.HttpServerConfig);
                await Driver.RunEventMethodsAsync(bot, @event, cancellationToken);
            }
        );
    }

    private static readonly JsonSerializerOptions GetEventJsonSerializerOptions = new()
    {
        AllowOutOfOrderMetadataProperties = true,
    };

    private OneBotV11Event GetEvent(JsonElement eventElement)
    {
        // 这边应该要判断post_type是否存在以及是否是null
        var postType = eventElement.GetProperty("post_type").GetString();
        var tp = postType switch
        {
            "meta_event" => typeof(BaseMetaEvent),
            "notice" => GetNoticeEventType(eventElement),
            "message" or "message_sent" => typeof(BaseMessageEvent),
            "request" => typeof(RequestBase),
            _ => typeof(OneBotV11Event),
        };
        return (OneBotV11Event)eventElement.Deserialize(tp, GetEventJsonSerializerOptions)!;
    }

    private Type GetNoticeEventType(JsonElement eventElement)
    {
        var noticeType = eventElement.GetProperty("notice_type").GetString();
        if (noticeType == "notify" && eventElement.TryGetProperty("sub_type", out var subType))
        {
            return typeof(NoticeBase);
        }

        return typeof(NoticeBase);
    }

    private static async Task<bool> VerifySignature(HttpContext context, string key)
    {
        using var reader = new StreamReader(context.Request.Body);
        string requestBody = await reader.ReadToEndAsync();
        byte[] requestData = Encoding.UTF8.GetBytes(requestBody);

        string receivedSigHeader = context.Request.Headers["X-Signature"].FirstOrDefault() ?? "";

        return VerifySignature(requestData, receivedSigHeader, key);
    }

    private static bool VerifySignature(
        byte[] requestData,
        string receivedSigHeader,
        string secretKey
    )
    {
        try
        {
            // 检查签名头格式
            if (string.IsNullOrEmpty(receivedSigHeader) || !receivedSigHeader.StartsWith("sha1="))
            {
                return false;
            }

            // 提取接收到的签名
            string receivedSig = receivedSigHeader.Substring("sha1=".Length);

            // 计算HMAC-SHA1签名
            using var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secretKey));
            byte[] hashBytes = hmac.ComputeHash(requestData);
            string computedSig = Convert.ToHexStringLower(hashBytes);

            // 比较签名（使用恒定时间比较以防止时序攻击）
            return CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(computedSig),
                Encoding.UTF8.GetBytes(receivedSig)
            );
        }
        catch
        {
            return false;
        }
    }
}
