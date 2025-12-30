using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Metas;

/// <summary>
/// 多态转换器：根据 <c>meta_event_type</c> 字段决定具体的元事件类型。
/// </summary>
public class BaseMetaEventTypeConverter : AddPolyTypeConverter<BaseMetaEvent>
{
    protected override string PolyTypeName => "meta_event_type";

    protected override ICollection<(object, Type)>? GetPolyTypes()
    {
        return [("lifecycle", typeof(LifecycleEvent)), ("heartbeat", typeof(HeartbeatEvent))];
    }
}

/// <summary>
/// OneBot v11 元事件基类，表示与 OneBot 运行状态相关的事件。
/// 对应 <c>post_type=meta_event</c> 事件。
/// 元事件与聊天软件无关，而是 OneBot 自身产生的事件。
/// </summary>
[JsonConverter(typeof(BaseMetaEventTypeConverter))]
public class BaseMetaEvent : OneBotV11Event
{
    /// <summary>
    /// 元事件类型（lifecycle/heartbeat）。
    /// </summary>
    [JsonPropertyName("meta_event_type")]
    public MetaEventType MetaEventType { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MetaEventType
{
    /// <summary>
    /// 生命周期事件。
    /// </summary>
    [JsonStringEnumMemberName("lifecycle")]
    Lifecycle,

    /// <summary>
    /// 心跳事件。
    /// </summary>
    [JsonStringEnumMemberName("heartbeat")]
    Heartbeat,
}
