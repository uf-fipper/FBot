using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 撤回消息请求参数
/// </summary>
public record DeleteMsgDto
{
    /// <summary>
    /// 消息 ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public required int MessageId { get; init; }
}
