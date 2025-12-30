using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 好友消息撤回通知事件，表示好友消息被撤回。
/// 对应 <c>notice_type=friend_recall</c>。
/// </summary>
public class FriendRecallNoticeEvent : NoticeBase
{
    /// <summary>
    /// 好友 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 被撤回的消息 ID。
    /// </summary>
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }
}
