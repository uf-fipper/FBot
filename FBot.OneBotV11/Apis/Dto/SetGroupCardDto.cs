using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 设置群名片请求参数
/// </summary>
public record SetGroupCardDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; set; }

    /// <summary>
    /// 要设置的 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public required long UserId { get; set; }

    /// <summary>
    /// 群名片内容，不填或空字符串表示删除群名片
    /// </summary>
    [JsonPropertyName("card")]
    public string? Card { get; set; }
}
