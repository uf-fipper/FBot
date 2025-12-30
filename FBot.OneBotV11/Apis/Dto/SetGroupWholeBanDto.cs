using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 群组全员禁言请求参数
/// </summary>
public record SetGroupWholeBanDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; set; }

    /// <summary>
    /// 是否禁言，默认 true
    /// </summary>
    [JsonPropertyName("enable")]
    public bool Enable { get; set; } = true;
}
