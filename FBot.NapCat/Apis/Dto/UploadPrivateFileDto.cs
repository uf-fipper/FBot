using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 上传私聊文件请求
/// </summary>
public record UploadPrivateFileDto
{
    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }

    /// <summary>
    /// 文件
    /// </summary>
    [JsonPropertyName("file")]
    public required string File { get; set; }

    /// <summary>
    /// 文件名
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
