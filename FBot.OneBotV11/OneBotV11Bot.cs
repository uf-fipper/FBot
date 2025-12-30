using System.Net;
using System.Net.WebSockets;
using System.Text.Json;
using FBot.OneBotV11.Apis.Extensions;
using FBot.OneBotV11.Apis.Vo;
using FBot.OneBotV11.Events.Messages;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11;

public interface IOneBotV11Bot : IBot
{
    long SelfId { get; }

    OneBotV11Adapter Adapter { get; }

    Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params);
}

public class OneBotV11Bot : IOneBotV11Bot
{
    public long SelfId { get; }

    public OneBotV11Adapter Adapter { get; }

    private OneBotV11Bot(OneBotV11Adapter adapter, long id)
    {
        Adapter = adapter;
        SelfId = id;
    }

    public OneBotV11Bot(OneBotV11Adapter adapter, long id, HttpServerConfig httpServerConfig)
        : this(adapter, id)
    {
        HttpServerConfig = httpServerConfig;
    }

    public OneBotV11Bot(OneBotV11Adapter adapter, long id, WebSocket webSocket)
        : this(adapter, id)
    {
        WebSocket = webSocket;
    }

    public async Task<bool> SendAsync(IEvent ev, Message message)
    {
        switch (ev)
        {
            case GroupMessageEvent e:
                await this.SendGroupMsgAsync(new() { GroupId = e.GroupId, Message = message });
                return true;
            case PrivateMessageEvent e:
                await this.SendPrivateMsgAsync(new() { UserId = e.UserId, Message = message });
                return true;
        }

        return false;
    }

    internal HttpServerConfig? HttpServerConfig { get; set; }

    internal WebSocket? WebSocket { get; set; }

    public async Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params)
    {
        if (WebSocket is not null)
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
                return value.Value.Deserialize<BaseResponseVo<TVo>>()!;
            }
        }

        if (HttpServerConfig is not null)
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

            var res = await response.Content.ReadFromJsonAsync<BaseResponseVo<TVo>>();
            return res!;
        }

        throw new NotSupportedException();
    }
}
