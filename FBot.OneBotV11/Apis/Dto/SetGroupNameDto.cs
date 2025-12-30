using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 设置群名请求参数
/// </summary>
public record SetGroupNameDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    /// <summary>
    /// 新群名
    /// </summary>
    [JsonPropertyName("group_name")]
    public required string GroupName { get; init; }
}
