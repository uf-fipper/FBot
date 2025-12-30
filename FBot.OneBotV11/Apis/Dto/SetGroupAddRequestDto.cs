using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 处理加群请求／邀请请求参数
/// </summary>
public record SetGroupAddRequestDto
{
    /// <summary>
    /// 加群请求的 flag（需从上报的数据中获得）
    /// </summary>
    [JsonPropertyName("flag")]
    public required string Flag { get; init; }

    /// <summary>
    /// 请求类型（需要和上报消息中的 sub_type 字段相符），add 或 invite
    /// </summary>
    [JsonPropertyName("sub_type")]
    public required string SubType { get; init; }

    /// <summary>
    /// 是否同意请求／邀请，默认 true
    /// </summary>
    [JsonPropertyName("approve")]
    public bool Approve { get; init; } = true;

    /// <summary>
    /// 拒绝理由（仅在拒绝时有效）
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; init; }
}
