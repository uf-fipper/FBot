using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 群成员减少通知事件，表示有成员离开群聊。
/// 对应 <c>notice_type=group_decrease</c>。
/// </summary>
public class GroupDecreaseNoticeEvent : NoticeBase
{
    /// <summary>
    /// 事件子类型，表示离开方式。
    /// </summary>
    [JsonPropertyName("sub_type")]
    public GroupDecreaseSubType SubType { get; set; }

    /// <summary>
    /// 群号。
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 操作者 QQ 号（如果是主动退群，则和 user_id 相同）。
    /// </summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }

    /// <summary>
    /// 离开者 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GroupDecreaseSubType
{
    /// <summary>
    /// 主动退群。
    /// </summary>
    [JsonStringEnumMemberName("leave")]
    Leave,

    /// <summary>
    /// 成员被踢。
    /// </summary>
    [JsonStringEnumMemberName("kick")]
    Kick,

    /// <summary>
    /// 登录号被踢。
    /// </summary>
    [JsonStringEnumMemberName("kick_me")]
    KickMe,
}
