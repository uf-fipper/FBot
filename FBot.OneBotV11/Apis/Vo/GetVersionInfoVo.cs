using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取版本信息响应数据
/// </summary>
public record GetVersionInfoVo
{
    /// <summary>
    /// 应用标识，如 mirai-native
    /// </summary>
    [JsonPropertyName("app_name")]
    public string AppName { get; set; } = string.Empty;

    /// <summary>
    /// 应用版本，如 1.2.3
    /// </summary>
    [JsonPropertyName("app_version")]
    public string AppVersion { get; set; } = string.Empty;

    /// <summary>
    /// OneBot 标准版本，如 v11
    /// </summary>
    [JsonPropertyName("protocol_version")]
    public string ProtocolVersion { get; set; } = string.Empty;
}
