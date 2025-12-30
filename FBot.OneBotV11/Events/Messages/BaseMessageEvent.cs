using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Events.Messages;

/// <summary>
/// 多态转换器：根据 <c>message_type</c> 字段决定具体的消息事件类型。
/// </summary>
public class BaseMessageEventTypeConverter : AddPolyTypeConverter<BaseMessageEvent>
{
    protected override string PolyTypeName => "message_type";

    protected override ICollection<(object, Type)>? GetPolyTypes()
    {
        return [("private", typeof(PrivateMessageEvent)), ("group", typeof(GroupMessageEvent))];
    }
}

/// <summary>
/// 基础消息事件，包含私聊/群聊消息的公共字段。
/// 对应 OneBot v11 的 <c>post_type=message</c> 事件中的通用字段。
/// </summary>
[JsonConverter(typeof(BaseMessageEventTypeConverter))]
public class BaseMessageEvent : OneBotV11Event
{
    /// <summary>
    /// 消息类型（private/group）。
    /// </summary>
    [JsonPropertyName("message_type")]
    public MessageTypeEnum MessageType { get; set; }

    /// <summary>
    /// 消息子类型（例如 friend/group/other）。
    /// </summary>
    [JsonPropertyName("sub_type")]
    public MessageSubTypeEnum SubType { get; set; }

    /// <summary>
    /// 消息 ID。
    /// </summary>
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }

    /// <summary>
    /// 发送者 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 解析后的消息段列表。
    /// </summary>
    [JsonPropertyName("message")]
    public Message Message { get; set; } = null!;

    /// <summary>
    /// 原始消息文本（未解析 CQ 码）。
    /// </summary>
    [JsonPropertyName("raw_message")]
    public string RawMessage { get; set; } = null!;

    /// <summary>
    /// 字体（客户端发送时携带的 font 字段）。
    /// </summary>
    [JsonPropertyName("font")]
    public int Font { get; set; }

    public Message GetMessage() => Message;
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageTypeEnum
{
    [JsonStringEnumMemberName("private")]
    Private,

    [JsonStringEnumMemberName("group")]
    Group,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageSubTypeEnum
{
    [JsonStringEnumMemberName("friend")]
    Friend,

    [JsonStringEnumMemberName("group")]
    Group,

    [JsonStringEnumMemberName("other")]
    Other,
}
