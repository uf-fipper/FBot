using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 处理群添加请求
/// </summary>
public record SetGroupAddRequestDto
{
    /// <summary>
    /// 请求标志
    /// </summary>
    [JsonPropertyName("flag")]
    public required string Flag { get; set; }

    /// <summary>
    /// 是否同意
    /// </summary>
    [JsonPropertyName("approve")]
    public bool Approve { get; set; }

    /// <summary>
    /// 拒绝原因
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}
