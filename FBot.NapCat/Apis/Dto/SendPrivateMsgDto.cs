using System.Text.Json.Serialization;
using FBot.NapCat.Apis.Shared;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 发送私聊消息请求
/// </summary>
public record SendPrivateMsgDto
{
    /// <summary>
    /// 目标用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; set; }
}
