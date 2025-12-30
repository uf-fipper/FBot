using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Metas;

/// <summary>
/// 生命周期事件，表示 OneBot 启用、停用或 WebSocket 连接成功。
/// 对应 <c>meta_event_type=lifecycle</c>。
/// </summary>
public class LifecycleEvent : BaseMetaEvent
{
    /// <summary>
    /// 事件子类型，表示具体的生命周期状态。
    /// </summary>
    [JsonPropertyName("sub_type")]
    public LifecycleSubType SubType { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LifecycleSubType
{
    /// <summary>
    /// OneBot 启用。
    /// 目前仅 HTTP POST 上报方式可收到此事件。
    /// </summary>
    [JsonStringEnumMemberName("enable")]
    Enable,

    /// <summary>
    /// OneBot 停用。
    /// 目前仅 HTTP POST 上报方式可收到此事件。
    /// </summary>
    [JsonStringEnumMemberName("disable")]
    Disable,

    /// <summary>
    /// WebSocket 连接成功。
    /// 仅正向 WebSocket 和反向 WebSocket 可收到此事件。
    /// </summary>
    [JsonStringEnumMemberName("connect")]
    Connect,
}
