using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetRecentContactVo
{
    [JsonPropertyName("lastestMsg")]
    public MessageInner LastestMsg { get; set; } = null!;

    [JsonPropertyName("peerUin")]
    public string PeerUin { get; set; } = null!;

    [JsonPropertyName("remark")]
    public string Remark { get; set; } = null!;

    [JsonPropertyName("msgTime")]
    public string MsgTime { get; set; } = null!;

    [JsonPropertyName("chatType")]
    public int ChatType { get; set; }

    [JsonPropertyName("msgId")]
    public string MsgId { get; set; } = null!;

    [JsonPropertyName("sendNickName")]
    public string SendNickName { get; set; } = null!;

    [JsonPropertyName("sendMemberName")]
    public string SendMemberName { get; set; } = null!;

    [JsonPropertyName("peerName")]
    public string PeerName { get; set; } = null!;
}
