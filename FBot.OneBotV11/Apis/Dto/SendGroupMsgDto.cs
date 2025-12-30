using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 发送群消息请求参数
/// </summary>
public record SendGroupMsgDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; set; }

    /// <summary>
    /// 要发送的内容
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; set; }
}
