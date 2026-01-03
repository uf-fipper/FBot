using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取群公告请求
/// </summary>
public record GetGroupNoticeDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }
}
