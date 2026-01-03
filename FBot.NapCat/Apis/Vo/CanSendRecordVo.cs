using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record CanSendRecordVo
{
    [JsonPropertyName("yes")]
    public bool Yes { get; set; }
}
