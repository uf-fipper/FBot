using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 创建群文件文件夹请求
/// </summary>
public record CreateGroupFileFolderDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 文件夹名称
    /// </summary>
    [JsonPropertyName("folder_name")]
    public required string FolderName { get; set; }
}
