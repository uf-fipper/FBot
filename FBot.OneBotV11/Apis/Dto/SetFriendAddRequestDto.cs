using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 处理加好友请求请求参数
/// </summary>
public record SetFriendAddRequestDto
{
    /// <summary>
    /// 加好友请求的 flag（需从上报的数据中获得）
    /// </summary>
    [JsonPropertyName("flag")]
    public required string Flag { get; set; }

    /// <summary>
    /// 是否同意请求，默认 true
    /// </summary>
    [JsonPropertyName("approve")]
    public bool Approve { get; set; } = true;

    /// <summary>
    /// 添加后的好友备注（仅在同意时有效）
    /// </summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; set; }
}
