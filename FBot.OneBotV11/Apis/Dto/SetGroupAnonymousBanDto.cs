using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 群组匿名用户禁言请求参数
/// </summary>
public record SetGroupAnonymousBanDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; set; }

    /// <summary>
    /// 可选，要禁言的匿名用户对象（群消息上报的 anonymous 字段）
    /// </summary>
    [JsonPropertyName("anonymous")]
    public AnonymousInfo? Anonymous { get; set; }

    /// <summary>
    /// 可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）
    /// </summary>
    [JsonPropertyName("anonymous_flag")]
    public string? AnonymousFlag { get; set; }

    /// <summary>
    /// 禁言时长，单位秒，无法取消匿名用户禁言，默认 30 分钟
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; } = 30 * 60;
}
