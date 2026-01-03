using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置模型展示请求
/// </summary>
public record SetModelShowDto
{
    /// <summary>
    /// 模型
    /// </summary>
    [JsonPropertyName("model")]
    public required string Model { get; set; }

    /// <summary>
    /// 模型展示
    /// </summary>
    [JsonPropertyName("model_show")]
    public required string ModelShow { get; set; }
}
