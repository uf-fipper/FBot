using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 转发单条消息到好友请求
/// </summary>
public record ForwardFriendSingleMsgDto
{
    /// <summary>
    /// 好友用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }

    /// <summary>
    /// 消息ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public required StringOrInteger MessageId { get; set; }
}
