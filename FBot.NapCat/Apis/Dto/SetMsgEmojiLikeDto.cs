using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置消息表情点赞请求
/// </summary>
public record SetMsgEmojiLikeDto
{
    /// <summary>
    /// 消息ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public required StringOrInteger MessageId { get; set; }

    /// <summary>
    /// 表情ID
    /// </summary>
    [JsonPropertyName("emoji_id")]
    public int EmojiId { get; set; }

    /// <summary>
    /// 是否设置
    /// </summary>
    [JsonPropertyName("set")]
    public bool Set { get; set; }
}
