using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取精华消息列表请求
/// </summary>
public record GetEssenceMsgListDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }
}
