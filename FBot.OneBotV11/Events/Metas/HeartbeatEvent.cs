using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Metas;

/// <summary>
/// 心跳事件，定期上报 OneBot 的状态信息。
/// 对应 <c>meta_event_type=heartbeat</c>。
/// </summary>
public class HeartbeatEvent : BaseMetaEvent
{
    /// <summary>
    /// 状态信息，内容与 <c>get_status</c> 接口的快速操作相同。
    /// </summary>
    [JsonPropertyName("status")]
    public HeartbeatStatus Status { get; set; } = null!;

    /// <summary>
    /// 到下次心跳的间隔，单位毫秒。
    /// </summary>
    [JsonPropertyName("interval")]
    public long Interval { get; set; }
}

/// <summary>
/// 心跳状态信息，反映 OneBot 的当前运行状态。
/// </summary>
public class HeartbeatStatus
{
    /// <summary>
    /// 当前在线状态。
    /// </summary>
    [JsonPropertyName("online")]
    public bool Online { get; set; }

    /// <summary>
    /// 连接是否正常。
    /// </summary>
    [JsonPropertyName("good")]
    public bool Good { get; set; }
}
