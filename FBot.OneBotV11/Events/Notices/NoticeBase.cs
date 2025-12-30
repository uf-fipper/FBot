using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 多态转换器：根据 <c>notice_type</c> 字段决定具体的通知事件类型。
/// </summary>
public class NoticeBaseTypeConverter : AddPolyTypeConverter<NoticeBase>
{
    protected override string PolyTypeName => "notice_type";

    protected override ICollection<(object, Type)>? GetPolyTypes()
    {
        return
        [
            ("group_upload", typeof(GroupUploadNoticeEvent)),
            ("group_admin", typeof(GroupAdminNoticeEvent)),
            ("group_decrease", typeof(GroupDecreaseNoticeEvent)),
            ("group_increase", typeof(GroupIncreaseNoticeEvent)),
            ("group_ban", typeof(GroupBanNoticeEvent)),
            ("friend_add", typeof(FriendAddNoticeEvent)),
            ("group_recall", typeof(GroupRecallNoticeEvent)),
            ("friend_recall", typeof(FriendRecallNoticeEvent)),
            ("notify", typeof(NotifyNoticeEvent)),
        ];
    }
}

/// <summary>
/// OneBot v11 通知事件基类，表示聊天软件中的各类通知。
/// 对应 <c>post_type=notice</c> 事件。
/// 包括群文件上传、管理员变动、成员增减、禁言、好友添加、消息撤回等。
/// </summary>
[JsonConverter(typeof(NoticeBaseTypeConverter))]
public class NoticeBase : OneBotV11Event
{
    /// <summary>
    /// 通知类型。
    /// </summary>
    [JsonPropertyName("notice_type")]
    public NoticeType NoticeType { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NoticeType
{
    /// <summary>
    /// 群文件上传。
    /// </summary>
    [JsonStringEnumMemberName("group_upload")]
    GroupUpload,

    /// <summary>
    /// 群管理员变动。
    /// </summary>
    [JsonStringEnumMemberName("group_admin")]
    GroupAdmin,

    /// <summary>
    /// 群成员减少。
    /// </summary>
    [JsonStringEnumMemberName("group_decrease")]
    GroupDecrease,

    /// <summary>
    /// 群成员增加。
    /// </summary>
    [JsonStringEnumMemberName("group_increase")]
    GroupIncrease,

    /// <summary>
    /// 群禁言。
    /// </summary>
    [JsonStringEnumMemberName("group_ban")]
    GroupBan,

    /// <summary>
    /// 好友添加。
    /// </summary>
    [JsonStringEnumMemberName("friend_add")]
    FriendAdd,

    /// <summary>
    /// 群消息撤回。
    /// </summary>
    [JsonStringEnumMemberName("group_recall")]
    GroupRecall,

    /// <summary>
    /// 好友消息撤回。
    /// </summary>
    [JsonStringEnumMemberName("friend_recall")]
    FriendRecall,

    /// <summary>
    /// 其他通知（戳一戳、红包运气王、荣誉变更等）。
    /// </summary>
    [JsonStringEnumMemberName("notify")]
    Notify,
}
