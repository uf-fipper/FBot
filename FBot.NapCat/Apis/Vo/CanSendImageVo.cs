using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record CanSendImageVo
{
    [JsonPropertyName("yes")]
    public bool Yes { get; set; }
}
