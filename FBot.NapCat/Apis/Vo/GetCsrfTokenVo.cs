using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetCsrfTokenVo
{
    [JsonPropertyName("token")]
    public int Token { get; set; }
}
