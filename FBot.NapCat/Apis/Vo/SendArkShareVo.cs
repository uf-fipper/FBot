using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record SendArkShareVo
{
    [JsonPropertyName("errCode")]
    public int ErrCode { get; set; }

    [JsonPropertyName("errMsg")]
    public string ErrMsg { get; set; } = null!;

    [JsonPropertyName("arkJson")]
    public string ArkJson { get; set; } = null!;
}
