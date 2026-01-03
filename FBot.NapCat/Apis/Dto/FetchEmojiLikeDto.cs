using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取表情点赞请求
/// </summary>
public record FetchEmojiLikeDto
{
    /// <summary>
    /// 消息ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public required StringOrInteger MessageId { get; set; }

    /// <summary>
    /// 表情ID
    /// </summary>
    [JsonPropertyName("emojiId")]
    public required string EmojiId { get; set; }

    /// <summary>
    /// 表情类型
    /// </summary>
    [JsonPropertyName("emojiType")]
    public required string EmojiType { get; set; }

    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public StringOrInteger? GroupId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public StringOrInteger? UserId { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }
}
