using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 群组设置管理员请求参数
/// </summary>
public record SetGroupAdminDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; set; }

    /// <summary>
    /// 要设置管理员的 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public required long UserId { get; set; }

    /// <summary>
    /// true 为设置，false 为取消，默认 true
    /// </summary>
    [JsonPropertyName("enable")]
    public bool Enable { get; set; } = true;
}
