using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 群管理员变动通知事件，表示群成员的管理员权限发生变化。
/// 对应 <c>notice_type=group_admin</c>。
/// </summary>
public class GroupAdminNoticeEvent : NoticeBase
{
    /// <summary>
    /// 事件子类型，表示设置或取消管理员。
    /// </summary>
    [JsonPropertyName("sub_type")]
    public GroupAdminSubType SubType { get; set; }

    /// <summary>
    /// 群号。
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 管理员 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GroupAdminSubType
{
    /// <summary>
    /// 设置管理员。
    /// </summary>
    [JsonStringEnumMemberName("set")]
    Set,

    /// <summary>
    /// 取消管理员。
    /// </summary>
    [JsonStringEnumMemberName("unset")]
    Unset,
}
