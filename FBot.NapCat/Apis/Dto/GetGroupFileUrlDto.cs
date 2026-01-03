using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取群文件下载链接请求
/// </summary>
public record GetGroupFileUrlDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 文件ID
    /// </summary>
    [JsonPropertyName("file_id")]
    public required string FileId { get; set; }
}
