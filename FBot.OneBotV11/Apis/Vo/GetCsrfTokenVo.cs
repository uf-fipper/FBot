using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取 CSRF Token 响应数据
/// </summary>
public record GetCsrfTokenVo
{
    /// <summary>
    /// CSRF Token
    /// </summary>
    [JsonPropertyName("token")]
    public int Token { get; set; }
}
