using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 获取 QQ 相关接口凭证请求参数（get_cookies 和 get_csrf_token 的合并）
/// </summary>
public record GetCredentialsDto
{
    /// <summary>
    /// 需要获取 cookies 的域名
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; init; }
}
