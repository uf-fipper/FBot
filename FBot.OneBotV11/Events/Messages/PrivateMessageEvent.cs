using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages;

/// <summary>
/// 私聊消息事件，包含私聊特有的字段，例如发送者信息。
/// 对应 <c>message_type=private</c>。
/// </summary>
public class PrivateMessageEvent : BaseMessageEvent
{
    /// <summary>
    /// 发送者信息（好友/私聊发送者）。
    /// </summary>
    [JsonPropertyName("sender")]
    public FriendSender Sender { get; set; } = null!;
}
