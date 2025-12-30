using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 发送私聊消息请求参数
/// </summary>
public record SendPrivateMsgDto
{
    /// <summary>
    /// 对方 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public required long UserId { get; set; }

    /// <summary>
    /// 要发送的内容
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; set; }
}
