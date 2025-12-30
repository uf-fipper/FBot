using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Shared;

public record CommonResponseDataSchema
{
    [JsonPropertyName("result")]
    public int Result { get; set; }

    [JsonPropertyName("errMsg")]
    public string ErrMsg { get; set; } = null!;
}
