namespace FBot.OneBotV11;

public class OneBotV11Config
{
    public List<OneBotV11BotConfig> Bots { get; set; } = [];
}

public class OneBotV11BotConfig
{
    /// <summary>
    /// <para>使用 Http 接收事件</para>
    /// <para>如果使用 Http 接收事件，则需要用 Http 调用接口</para>
    /// </summary>
    public HttpConfig? HttpConfig { get; set; }

    /// <summary>
    /// <para>主动发起 WebSocket 连接到 OneBot 服务器接收事件</para>
    /// <para>如果使用 WebSocket 接收事件，则使用 WebSocket 调用接口</para>
    /// </summary>
    public WebSocketServerConfig? WebSocketServerConfig { get; set; }

    /// <summary>
    /// <para>作为 WebSocket 客户端，等待 OneBot 服务器连接</para>
    /// <para>如果使用 WebSocket 接收事件，则使用 WebSocket 调用接口</para>
    /// </summary>
    public WebSocketClientConfig? WebSocketClientConfig { get; set; }
}

public class HttpConfig
{
    /// <summary>
    /// OneBot 服务器的 Http 接口配置，供请求 api 使用
    /// </summary>
    public required HttpServerConfig HttpServerConfig { get; set; }

    /// <summary>
    /// 当前机器人的 Http 接口配置，供接收事件使用
    /// </summary>
    public required HttpClientConfig HttpClientConfig { get; set; }
}

public class HttpServerConfig
{
    public string Url { get; set; } = "";

    public string Token { get; set; } = "";
}

public class HttpClientConfig
{
    public string Url { get; set; } = "";

    public string Token { get; set; } = "";
}

public class WebSocketServerConfig
{
    public string Url { get; set; } = "";

    public string Token { get; set; } = "";
}

public class WebSocketClientConfig
{
    public string Url { get; set; } = "";

    public string Token { get; set; } = "";
}
