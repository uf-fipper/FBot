using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取凭据请求
/// </summary>
public record GetCredentialsDto
{
    /// <summary>
    /// 域名
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }
}
