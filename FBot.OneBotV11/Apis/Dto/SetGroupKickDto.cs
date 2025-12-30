using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 群组踢人请求参数
/// </summary>
public record SetGroupKickDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    /// <summary>
    /// 要踢的 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public required long UserId { get; init; }

    /// <summary>
    /// 拒绝此人的加群请求
    /// </summary>
    [JsonPropertyName("reject_add_request")]
    public bool RejectAddRequest { get; init; } = false;
}
