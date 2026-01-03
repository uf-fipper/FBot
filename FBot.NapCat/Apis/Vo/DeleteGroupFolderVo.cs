using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record DeleteGroupFolderVo
{
    [JsonPropertyName("retCode")]
    public int RetCode { get; set; }

    [JsonPropertyName("retMsg")]
    public string RetMsg { get; set; } = null!;

    [JsonPropertyName("clientWording")]
    public string ClientWording { get; set; } = null!;
}
