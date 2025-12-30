using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 群禁言通知事件，表示群成员被禁言或解除禁言。
/// 对应 <c>notice_type=group_ban</c>。
/// </summary>
public class GroupBanNoticeEvent : NoticeBase
{
    /// <summary>
    /// 事件子类型，表示禁言或解除禁言。
    /// </summary>
    [JsonPropertyName("sub_type")]
    public GroupBanSubType SubType { get; set; }

    /// <summary>
    /// 群号。
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 操作者 QQ 号。
    /// </summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }

    /// <summary>
    /// 被禁言 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 禁言时长，单位秒（仅在禁言时有值）。
    /// </summary>
    [JsonPropertyName("duration")]
    public long Duration { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GroupBanSubType
{
    /// <summary>
    /// 禁言。
    /// </summary>
    [JsonStringEnumMemberName("ban")]
    Ban,

    /// <summary>
    /// 解除禁言。
    /// </summary>
    [JsonStringEnumMemberName("lift_ban")]
    LiftBan,
}
