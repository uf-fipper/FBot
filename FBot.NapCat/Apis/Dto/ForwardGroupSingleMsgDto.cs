using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 转发单条消息到群请求
/// </summary>
public record ForwardGroupSingleMsgDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 消息ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public required StringOrInteger MessageId { get; set; }
}
