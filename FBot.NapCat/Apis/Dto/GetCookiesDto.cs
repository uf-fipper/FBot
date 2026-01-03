using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取Cookies请求
/// </summary>
public record GetCookiesDto
{
    /// <summary>
    /// 域名
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }
}
