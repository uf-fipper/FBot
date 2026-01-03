using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupMsgHistoryVo
{
    [JsonPropertyName("messages")]
    public MessageInner[] Messages { get; set; } = null!;
}

public record MessageInner
{
    [JsonPropertyName("self_id")]
    public long SelfId { get; set; }

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("message_id")]
    public long MessageId { get; set; }

    [JsonPropertyName("message_seq")]
    public int MessageSeq { get; set; }

    [JsonPropertyName("real_id")]
    public int RealId { get; set; }

    [JsonPropertyName("message_type")]
    public string MessageType { get; set; } = null!;

    [JsonPropertyName("sender")]
    public Sender Sender { get; set; } = null!;

    [JsonPropertyName("raw_message")]
    public string RawMessage { get; set; } = null!;

    [JsonPropertyName("font")]
    public int Font { get; set; }

    [JsonPropertyName("sub_type")]
    public string SubType { get; set; } = null!;

    [JsonPropertyName("message")]
    public Message MessageContent { get; set; } = null!;

    [JsonPropertyName("message_format")]
    public string MessageFormat { get; set; } = null!;

    [JsonPropertyName("post_type")]
    public string PostType { get; set; } = null!;

    [JsonPropertyName("message_sent_type")]
    public string MessageSentType { get; set; } = null!;

    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

public record Sender
{
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = null!;

    [JsonPropertyName("sex")]
    public string Sex { get; set; } = null!;

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("card")]
    public string Card { get; set; } = null!;

    [JsonPropertyName("role")]
    public string Role { get; set; } = null!;
}
