using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取群成员列表请求
/// </summary>
public record GetGroupMemberListDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 是否不使用缓存
    /// </summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; }
}
