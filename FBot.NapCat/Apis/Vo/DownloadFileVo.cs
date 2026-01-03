using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record DownloadFileVo
{
    [JsonPropertyName("file")]
    public string File { get; set; } = null!;
}
