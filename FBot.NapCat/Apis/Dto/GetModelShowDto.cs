using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取模型展示请求
/// </summary>
public record GetModelShowDto
{
    /// <summary>
    /// 模型
    /// </summary>
    [JsonPropertyName("model")]
    public required string Model { get; set; }
}
