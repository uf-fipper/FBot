using System.Net;
using System.Net.WebSockets;
using System.Text.Json;
using FBot.OneBotV11.Apis.Vo;

namespace FBot.OneBotV11;

public interface IOneBotV11Bot : IBot
{
    long SelfId { get; }

    OneBotV11Adapter Adapter { get; }

    Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params);
}

public class OneBotV11HttpBot(OneBotV11Adapter adapter, long id, HttpServerConfig httpServerConfig)
    : IOneBotV11Bot
{
    public long SelfId { get; } = id;

    public OneBotV11Adapter Adapter { get; } = adapter;

    public HttpServerConfig HttpServerConfig { get; } = httpServerConfig;

    public async Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params)
    {
        var httpServerConfig = HttpServerConfig;
        var httpClient = new HttpClient();
        if (!string.IsNullOrEmpty(httpServerConfig.Token))
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", httpServerConfig.Token);
        }

        var response = await httpClient.PostAsJsonAsync(httpServerConfig.Url, @params);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null!;
        }

        var res =
            await response.Content.ReadFromJsonAsync<BaseResponseVo<TVo>>()
            ?? throw new NotSupportedException("not support null response");
        return res;
    }
}

public class OneBotV11WebSocketBot(OneBotV11Adapter adapter, long id, WebSocket webSocket)
    : IOneBotV11Bot
{
    public long SelfId { get; } = id;

    public OneBotV11Adapter Adapter { get; } = adapter;

    public WebSocket WebSocket { get; } = webSocket;

    public async Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params)
    {
        var guid = Guid.NewGuid();
        Adapter.WebSocketResponses.Add(guid, null);
        await WebSocket.SendAsJsonAsync(
            new
            {
                action,
                @params,
                echo = guid,
            }
        );
        // 轮询查询结果
        var now = DateTime.Now;
        while (true)
        {
            var value = Adapter.WebSocketResponses[guid];
            if (value is null)
            {
                if (DateTime.Now - now > TimeSpan.FromSeconds(10))
                {
                    // 等待结果超时
                    Adapter.WebSocketResponses.Remove(guid);
                    throw new TimeoutException();
                }
                await Task.Delay(100);
                continue;
            }
            // 获取到结果，释放内存
            Adapter.WebSocketResponses.Remove(guid);
            var result =
                value.Value.Deserialize<BaseResponseVo<TVo>>()
                ?? throw new NotSupportedException("not support null response");
            return result;
        }
    }
}
