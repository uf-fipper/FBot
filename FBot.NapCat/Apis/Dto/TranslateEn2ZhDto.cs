using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 英文转中文翻译请求
/// </summary>
public record TranslateEn2ZhDto
{
    /// <summary>
    /// 单词列表
    /// </summary>
    [JsonPropertyName("words")]
    public required string[] Words { get; set; }
}
