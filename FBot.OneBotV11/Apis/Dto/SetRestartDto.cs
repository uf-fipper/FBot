using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 重启 OneBot 实现请求参数
/// </summary>
public record SetRestartDto
{
    /// <summary>
    /// 要延迟的毫秒数，如果默认情况下无法重启，可以尝试设置延迟为 2000 左右，默认 0
    /// </summary>
    [JsonPropertyName("delay")]
    public int Delay { get; init; } = 0;
}
