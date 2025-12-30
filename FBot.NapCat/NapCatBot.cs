using System.Net.WebSockets;
using FBot.OneBotV11;

namespace FBot.NapCat;

public class NapCatBot : OneBotV11Bot
{
    public NapCatBot(OneBotV11Adapter adapter, long id, HttpServerConfig httpServerConfig)
        : base(adapter, id, httpServerConfig) { }

    public NapCatBot(OneBotV11Adapter adapter, long id, WebSocket webSocket)
        : base(adapter, id, webSocket) { }
}
