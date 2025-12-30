using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取 Cookies 响应数据
/// </summary>
public record GetCookiesVo
{
    /// <summary>
    /// Cookies
    /// </summary>
    [JsonPropertyName("cookies")]
    public string Cookies { get; set; } = string.Empty;
}
