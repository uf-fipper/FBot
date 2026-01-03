using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetRobotUinRangeVo
{
    [JsonPropertyName("minUin")]
    public string MinUin { get; set; } = null!;

    [JsonPropertyName("maxUin")]
    public string MaxUin { get; set; } = null!;
}
