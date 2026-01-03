using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetCookiesVo
{
    [JsonPropertyName("cookies")]
    public string Cookies { get; set; } = null!;

    [JsonPropertyName("bkn")]
    public string Bkn { get; set; } = null!;
}
