using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取 QQ 相关接口凭证响应数据（get_cookies 和 get_csrf_token 的合并）
/// </summary>
public record GetCredentialsVo
{
    /// <summary>
    /// Cookies
    /// </summary>
    [JsonPropertyName("cookies")]
    public string Cookies { get; init; } = string.Empty;

    /// <summary>
    /// CSRF Token
    /// </summary>
    [JsonPropertyName("csrf_token")]
    public int CsrfToken { get; init; }
}
