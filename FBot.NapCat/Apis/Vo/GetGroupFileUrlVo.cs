using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupFileUrlVo
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
}
