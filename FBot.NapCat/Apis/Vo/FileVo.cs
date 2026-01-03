using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record FileVo
{
    [JsonPropertyName("file")]
    public string File { get; set; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    [JsonPropertyName("file_size")]
    public string FileSize { get; set; } = null!;

    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = null!;

    [JsonPropertyName("base64")]
    public string Base64 { get; set; } = null!;
}
