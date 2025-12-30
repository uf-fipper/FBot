using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 发送私聊消息响应数据
/// </summary>
public record SendPrivateMsgVo
{
    /// <summary>
    /// 消息 ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public long MessageId { get; init; }
}
