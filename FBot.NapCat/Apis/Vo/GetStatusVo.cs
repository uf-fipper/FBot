using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetStatusVo
{
    [JsonPropertyName("online")]
    public bool Online { get; set; }

    [JsonPropertyName("good")]
    public bool Good { get; set; }

    [JsonPropertyName("stat")]
    public object Stat { get; set; } = null!;
}
