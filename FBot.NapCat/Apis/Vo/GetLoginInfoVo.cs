using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetLoginInfoVo
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = null!;
}
