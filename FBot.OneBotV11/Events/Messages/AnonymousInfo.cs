using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages;

/// <summary>
/// 匿名用户信息，仅在匿名消息中出现。
/// 包含匿名标识、名称和操作所需的 flag。
/// </summary>
public class AnonymousInfo
{
    /// <summary>
    /// 匿名用户 ID。
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// 匿名用户名称。
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// 匿名用户 flag，在调用禁言 API 时需要传入。
    /// </summary>
    [JsonPropertyName("flag")]
    public string Flag { get; set; } = null!;
}
