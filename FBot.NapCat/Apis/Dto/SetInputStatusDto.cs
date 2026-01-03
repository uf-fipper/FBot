using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置输入状态请求
/// </summary>
public record SetInputStatusDto
{
    /// <summary>
    /// 事件类型
    /// </summary>
    [JsonPropertyName("eventType")]
    public int EventType { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }
}
