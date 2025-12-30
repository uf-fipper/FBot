using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 获取群信息请求参数
/// </summary>
public record GetGroupInfoDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    /// <summary>
    /// 是否不使用缓存（使用缓存可能更新不及时，但响应更快），默认 false
    /// </summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; init; } = false;
}
