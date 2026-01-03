using System.Text.Json.Serialization;
using FBot.NapCat.Apis.Shared;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 发送群消息请求
/// </summary>
public record SendGroupMsgDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; set; }
}
