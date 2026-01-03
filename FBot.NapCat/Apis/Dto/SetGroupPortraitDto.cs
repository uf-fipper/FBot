using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置群头像请求
/// </summary>
public record SetGroupPortraitDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 文件
    /// </summary>
    [JsonPropertyName("file")]
    public required string File { get; set; }
}
