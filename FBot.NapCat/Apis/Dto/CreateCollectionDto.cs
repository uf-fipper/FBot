using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 创建收藏请求
/// </summary>
public record CreateCollectionDto
{
    /// <summary>
    /// 原始数据
    /// </summary>
    [JsonPropertyName("rawData")]
    public required string RawData { get; set; }

    /// <summary>
    /// 简介
    /// </summary>
    [JsonPropertyName("brief")]
    public required string Brief { get; set; }
}
