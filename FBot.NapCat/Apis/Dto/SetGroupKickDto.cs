using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 群移除成员请求
/// </summary>
public record SetGroupKickDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 要移除的成员用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }

    /// <summary>
    /// 是否拒绝加群请求
    /// </summary>
    [JsonPropertyName("reject_add_request")]
    public bool RejectAddRequest { get; set; }
}
