using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取群列表请求
/// </summary>
public record GetGroupListDto
{
    /// <summary>
    /// 分页令牌
    /// </summary>
    [JsonPropertyName("next_token")]
    public string? NextToken { get; set; }
}
