using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取最近联系人请求
/// </summary>
public record GetRecentContactDto
{
    /// <summary>
    /// 数量
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}
