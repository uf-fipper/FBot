using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 检查是否可以发送语音响应数据
/// </summary>
public record CanSendRecordVo
{
    /// <summary>
    /// 是或否
    /// </summary>
    [JsonPropertyName("yes")]
    public bool Yes { get; init; }
}
