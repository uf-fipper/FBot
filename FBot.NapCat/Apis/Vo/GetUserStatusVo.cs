using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetUserStatusVo
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("ext_status")]
    public int ExtStatus { get; set; }
}
