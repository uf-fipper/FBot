using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取好友列表请求
/// </summary>
public record GetFriendListDto
{
    /// <summary>
    /// 是否不使用缓存
    /// </summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; }
}
