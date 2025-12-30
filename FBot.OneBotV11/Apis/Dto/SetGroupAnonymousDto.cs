using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 群组匿名请求参数
/// </summary>
public record SetGroupAnonymousDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    /// <summary>
    /// 是否允许匿名聊天，默认 true
    /// </summary>
    [JsonPropertyName("enable")]
    public bool Enable { get; init; } = true;
}
