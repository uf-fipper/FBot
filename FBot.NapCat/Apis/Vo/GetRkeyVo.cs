using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetRkeyVo
{
    [JsonPropertyName("rkey")]
    public string Rkey { get; set; } = null!;

    [JsonPropertyName("ttl")]
    public string Ttl { get; set; } = null!;

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }
}
