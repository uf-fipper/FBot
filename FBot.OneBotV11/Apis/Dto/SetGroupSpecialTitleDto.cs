using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 设置群组专属头衔请求参数
/// </summary>
public record SetGroupSpecialTitleDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    /// <summary>
    /// 要设置的 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public required long UserId { get; init; }

    /// <summary>
    /// 专属头衔，不填或空字符串表示删除专属头衔
    /// </summary>
    [JsonPropertyName("special_title")]
    public string? SpecialTitle { get; init; }

    /// <summary>
    /// 专属头衔有效期，单位秒，-1 表示永久，默认 -1
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; init; } = -1;
}
