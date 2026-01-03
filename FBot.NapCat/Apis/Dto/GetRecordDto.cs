using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取语音请求
/// </summary>
public record GetRecordDto
{
    /// <summary>
    /// 文件ID
    /// </summary>
    [JsonPropertyName("file_id")]
    public required string FileId { get; set; }

    /// <summary>
    /// 输出格式
    /// </summary>
    [JsonPropertyName("out_format")]
    public required string OutFormat { get; set; }
}
