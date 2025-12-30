using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 群成员增加通知事件，表示有新成员加入群聊。
/// 对应 <c>notice_type=group_increase</c>。
/// </summary>
public class GroupIncreaseNoticeEvent : NoticeBase
{
    /// <summary>
    /// 事件子类型，表示加入方式。
    /// </summary>
    [JsonPropertyName("sub_type")]
    public GroupIncreaseSubType SubType { get; set; }

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
    /// 加入者 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GroupIncreaseSubType
{
    /// <summary>
    /// 管理员已同意入群。
    /// </summary>
    [JsonStringEnumMemberName("approve")]
    Approve,

    /// <summary>
    /// 管理员邀请入群。
    /// </summary>
    [JsonStringEnumMemberName("invite")]
    Invite,
}
