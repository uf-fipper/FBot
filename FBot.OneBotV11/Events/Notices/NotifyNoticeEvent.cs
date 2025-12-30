using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 多态转换器：根据 <c>sub_type</c> 字段决定具体的 notify 事件类型。
/// </summary>
public class NotifyNoticeEventTypeConverter : AddPolyTypeConverter<NotifyNoticeEvent>
{
    protected override string PolyTypeName => "sub_type";

    protected override ICollection<(object, Type)>? GetPolyTypes()
    {
        return
        [
            ("poke", typeof(PokeNotifyEvent)),
            ("lucky_king", typeof(LuckyKingNotifyEvent)),
            ("honor", typeof(HonorNotifyEvent)),
        ];
    }
}

/// <summary>
/// 其他通知事件基类，包含戳一戳、红包运气王、荣誉变更等。
/// 对应 <c>notice_type=notify</c>。
/// </summary>
[JsonConverter(typeof(NotifyNoticeEventTypeConverter))]
public class NotifyNoticeEvent : NoticeBase
{
    /// <summary>
    /// 通知子类型。
    /// </summary>
    [JsonPropertyName("sub_type")]
    public NotifySubType SubType { get; set; }

    /// <summary>
    /// 发送者 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 群号。
    /// </summary>
    [JsonPropertyName("group_id")]
    public long? GroupId { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NotifySubType
{
    /// <summary>
    /// 戳一戳。
    /// </summary>
    [JsonStringEnumMemberName("poke")]
    Poke,

    /// <summary>
    /// 红包运气王。
    /// </summary>
    [JsonStringEnumMemberName("lucky_king")]
    LuckyKing,

    /// <summary>
    /// 群成员荣誉变更。
    /// </summary>
    [JsonStringEnumMemberName("honor")]
    Honor,
}

/// <summary>
/// 戳一戳通知事件，表示群内有人戳了其他成员。
/// 对应 <c>sub_type=poke</c>。
/// </summary>
public class PokeNotifyEvent : NotifyNoticeEvent
{
    /// <summary>
    /// 被戳者 QQ 号。
    /// </summary>
    [JsonPropertyName("target_id")]
    public long TargetId { get; set; }
}

/// <summary>
/// 红包运气王通知事件，表示有人抢红包获得了运气王。
/// 对应 <c>sub_type=lucky_king</c>。
/// </summary>
public class LuckyKingNotifyEvent : NotifyNoticeEvent
{
    /// <summary>
    /// 运气王 QQ 号。
    /// </summary>
    [JsonPropertyName("target_id")]
    public long TargetId { get; set; }
}

/// <summary>
/// 群成员荣誉变更通知事件，表示群成员获得了新的荣誉头衔。
/// 对应 <c>sub_type=honor</c>。
/// </summary>
public class HonorNotifyEvent : NotifyNoticeEvent
{
    /// <summary>
    /// 荣誉类型。
    /// </summary>
    [JsonPropertyName("honor_type")]
    public HonorType HonorType { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HonorType
{
    /// <summary>
    /// 龙王（活跃度最高）。
    /// </summary>
    [JsonStringEnumMemberName("talkative")]
    Talkative,

    /// <summary>
    /// 群聊之火。
    /// </summary>
    [JsonStringEnumMemberName("performer")]
    Performer,

    /// <summary>
    /// 快乐源泉。
    /// </summary>
    [JsonStringEnumMemberName("emotion")]
    Emotion,
}
