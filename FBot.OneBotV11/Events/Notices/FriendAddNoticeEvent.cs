using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 好友添加通知事件，表示成功添加了新好友。
/// 对应 <c>notice_type=friend_add</c>。
/// </summary>
public class FriendAddNoticeEvent : NoticeBase
{
    /// <summary>
    /// 新添加好友 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}
