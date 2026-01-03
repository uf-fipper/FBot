using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetCredentialsVo
{
    [JsonPropertyName("cookies")]
    public string Cookies { get; set; } = null!;

    [JsonPropertyName("token")]
    public int Token { get; set; }
}
