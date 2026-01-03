using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取自定义表情请求
/// </summary>
public record FetchCustomFaceDto
{
    /// <summary>
    /// 数量
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }
}
