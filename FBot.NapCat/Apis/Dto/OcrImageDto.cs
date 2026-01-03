using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// OCR图片识别请求
/// </summary>
public record OcrImageDto
{
    /// <summary>
    /// 图片内容
    /// </summary>
    [JsonPropertyName("image")]
    public required string Image { get; set; }
}
