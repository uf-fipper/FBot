using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 群组单人禁言请求参数
/// </summary>
public record SetGroupBanDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    /// <summary>
    /// 要禁言的 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public required long UserId { get; init; }

    /// <summary>
    /// 禁言时长，单位秒，0 表示取消禁言，默认 30 分钟
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; init; } = 30 * 60;
}
