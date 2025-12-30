using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages;

/// <summary>
/// 群消息事件，包含群号与群内发送者信息等字段。
/// 对应 <c>message_type=group</c>。
/// </summary>
public class GroupMessageEvent : BaseMessageEvent
{
    /// <summary>
    /// 群号。
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 匿名信息，如果不是匿名消息则为 null。
    /// </summary>
    [JsonPropertyName("anonymous")]
    public AnonymousInfo? Anonymous { get; set; }

    /// <summary>
    /// 群内发送者信息，包含角色/头衔等。
    /// </summary>
    [JsonPropertyName("sender")]
    public GroupSender Sender { get; set; } = null!;
}
