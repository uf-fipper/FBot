using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 获取 Cookies 请求参数
/// </summary>
public record GetCookiesDto
{
    /// <summary>
    /// 需要获取 cookies 的域名
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }
}
