using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record SendGroupAiRecordVo
{
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = null!;
}
