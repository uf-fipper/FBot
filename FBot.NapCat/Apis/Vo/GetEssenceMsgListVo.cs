using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.NapCat.Apis.Vo;

public record GetEssenceMsgListVo
{
    [JsonPropertyName("msg_seq")]
    public int MsgSeq { get; set; }

    [JsonPropertyName("msg_random")]
    public int MsgRandom { get; set; }

    [JsonPropertyName("sender_id")]
    public int SenderId { get; set; }

    [JsonPropertyName("sender_nick")]
    public string SenderNick { get; set; } = null!;

    [JsonPropertyName("operator_id")]
    public int OperatorId { get; set; }

    [JsonPropertyName("operator_nick")]
    public string OperatorNick { get; set; } = null!;

    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = null!;

    [JsonPropertyName("operator_time")]
    public string OperatorTime { get; set; } = null!;

    [JsonPropertyName("content")]
    public Message Content { get; set; } = null!;
}
