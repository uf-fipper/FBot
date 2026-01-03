using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置全群禁言请求
/// </summary>
public record SetGroupWholeBanDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 是否开启全群禁言
    /// </summary>
    [JsonPropertyName("enable")]
    public bool Enable { get; set; }
}
