using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetVersionInfoVo
{
    [JsonPropertyName("app_name")]
    public string AppName { get; set; } = null!;

    [JsonPropertyName("protocol_version")]
    public string ProtocolVersion { get; set; } = null!;

    [JsonPropertyName("app_version")]
    public string AppVersion { get; set; } = null!;
}
