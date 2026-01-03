using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取AI角色列表请求
/// </summary>
public record GetAiCharactersDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 聊天类型
    /// </summary>
    [JsonPropertyName("chat_type")]
    public required StringOrInteger ChatType { get; set; }
}
