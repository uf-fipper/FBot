using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 群消息撤回通知事件，表示群中有消息被撤回。
/// 对应 <c>notice_type=group_recall</c>。
/// </summary>
public class GroupRecallNoticeEvent : NoticeBase
{
    /// <summary>
    /// 群号。
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 消息发送者 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 操作者 QQ 号。
    /// </summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }

    /// <summary>
    /// 被撤回的消息 ID。
    /// </summary>
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }
}
