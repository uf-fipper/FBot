using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 退出群组请求参数
/// </summary>
public record SetGroupLeaveDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    /// <summary>
    /// 是否解散，如果登录号是群主，则仅在此项为 true 时能够解散，默认 false
    /// </summary>
    [JsonPropertyName("is_dismiss")]
    public bool IsDismiss { get; init; } = false;
}
