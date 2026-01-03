using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取文件夹内文件请求
/// </summary>
public record GetGroupFilesByFolderDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 文件夹ID
    /// </summary>
    [JsonPropertyName("folder_id")]
    public required string FolderId { get; set; }

    /// <summary>
    /// 文件数量
    /// </summary>
    [JsonPropertyName("file_count")]
    public int FileCount { get; set; }
}
