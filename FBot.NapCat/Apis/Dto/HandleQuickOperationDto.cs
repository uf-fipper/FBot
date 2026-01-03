using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 快速操作请求
/// </summary>
public record HandleQuickOperationDto
{
    /// <summary>
    /// 上下文
    /// </summary>
    [JsonPropertyName("context")]
    public required object Context { get; set; }

    /// <summary>
    /// 操作
    /// </summary>
    [JsonPropertyName("operation")]
    public required object Operation { get; set; }
}
