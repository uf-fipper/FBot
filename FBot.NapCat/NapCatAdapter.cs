using System.Net.WebSockets;
using FBot.OneBotV11;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FBot.NapCat;

public class NapCatAdapter : OneBotV11Adapter
{
    public ILogger<NapCatAdapter>? Logger { get; set; }

    public NapCatAdapter(
        FDriver driver,
        IOptions<OneBotV11Config> oneBotV11Config,
        ILogger<OneBotV11Adapter> oneBotV11AdapterLogger,
        ILogger<NapCatAdapter> logger
    )
        : base(driver, oneBotV11Config, oneBotV11AdapterLogger)
    {
        Logger = logger;
    }

    public NapCatAdapter(FDriver driver, IOptions<OneBotV11Config> oneBotV11Config)
        : base(driver, oneBotV11Config) { }

    protected override INapCatBot CreateBot(long id, HttpServerConfig serverConfig)
    {
        return new NapCatHttpBot(this, id, serverConfig);
    }

    protected override INapCatBot CreateBot(long id, WebSocket webSocket)
    {
        return new NapCatWebSocketBot(this, id, webSocket);
    }
}
