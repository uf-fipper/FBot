using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Requests;

/// <summary>
/// 加好友请求事件，表示有用户申请添加机器人为好友。
/// 对应 <c>request_type=friend</c>。
/// 需要通过快速操作来同意或拒绝此请求。
/// </summary>
public class FriendRequestEvent : RequestBase
{
    /// <summary>
    /// 发送请求的 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 验证信息。
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; } = null!;
}
