using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取群信息响应数据
/// </summary>
public record GetGroupInfoVo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; init; }

    /// <summary>
    /// 群名称
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; init; } = string.Empty;

    /// <summary>
    /// 成员数
    /// </summary>
    [JsonPropertyName("member_count")]
    public int MemberCount { get; init; }

    /// <summary>
    /// 最大成员数（群容量）
    /// </summary>
    [JsonPropertyName("max_member_count")]
    public int MaxMemberCount { get; init; }
}
