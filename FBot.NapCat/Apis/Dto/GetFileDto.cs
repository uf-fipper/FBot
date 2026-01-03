using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取文件请求
/// </summary>
public record GetFileDto
{
    /// <summary>
    /// 文件ID
    /// </summary>
    [JsonPropertyName("file_id")]
    public required string FileId { get; set; }
}
