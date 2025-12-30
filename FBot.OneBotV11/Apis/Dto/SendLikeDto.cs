using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 发送好友赞请求参数
/// </summary>
public record SendLikeDto
{
    /// <summary>
    /// 对方 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public required long UserId { get; init; }

    /// <summary>
    /// 赞的次数，每个好友每天最多 10 次
    /// </summary>
    [JsonPropertyName("times")]
    public int Times { get; init; } = 1;
}
