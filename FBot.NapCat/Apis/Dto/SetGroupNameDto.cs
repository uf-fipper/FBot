using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置群名称请求
/// </summary>
public record SetGroupNameDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 新群名称
    /// </summary>
    [JsonPropertyName("group_name")]
    public required string GroupName { get; set; }
}
