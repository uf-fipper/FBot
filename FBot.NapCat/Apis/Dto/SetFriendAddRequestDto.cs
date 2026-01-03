using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 处理好友添加请求
/// </summary>
public record SetFriendAddRequestDto
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
    /// 备注
    /// </summary>
    [JsonPropertyName("remark")]
    public required string Remark { get; set; }
}
