using System.Text.Json.Serialization;
using FBot.NapCat.Apis.Shared;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 发送转发消息请求
/// </summary>
public record SendForwardMsgDto
{
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
    /// 消息列表
    /// </summary>
    [JsonPropertyName("messages")]
    public required Message Messages { get; set; }

    /// <summary>
    /// 新闻条目
    /// </summary>
    [JsonPropertyName("news")]
    public NewsItem[]? News { get; set; }

    /// <summary>
    /// 提示
    /// </summary>
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }

    /// <summary>
    /// 摘要
    /// </summary>
    [JsonPropertyName("summary")]
    public required string Summary { get; set; }

    /// <summary>
    /// 来源
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }
}

/// <summary>
/// 新闻条目
/// </summary>
public record NewsItem
{
    /// <summary>
    /// 文本
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }
}
