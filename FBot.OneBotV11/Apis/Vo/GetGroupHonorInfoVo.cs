using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取群荣誉信息响应数据
/// </summary>
public record GetGroupHonorInfoVo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; init; }

    /// <summary>
    /// 当前龙王（仅 type 为 talkative 或 all 时有数据）
    /// </summary>
    [JsonPropertyName("current_talkative")]
    public HonorMemberInfo? CurrentTalkative { get; init; }

    /// <summary>
    /// 历史龙王（仅 type 为 talkative 或 all 时有数据）
    /// </summary>
    [JsonPropertyName("talkative_list")]
    public List<HonorMemberInfo>? TalkativeList { get; init; }

    /// <summary>
    /// 群聊之火（仅 type 为 performer 或 all 时有数据）
    /// </summary>
    [JsonPropertyName("performer_list")]
    public List<HonorMemberInfo>? PerformerList { get; init; }

    /// <summary>
    /// 群聊炽焰（仅 type 为 legend 或 all 时有数据）
    /// </summary>
    [JsonPropertyName("legend_list")]
    public List<HonorMemberInfo>? LegendList { get; init; }

    /// <summary>
    /// 冒尖小春笋（仅 type 为 strong_newbie 或 all 时有数据）
    /// </summary>
    [JsonPropertyName("strong_newbie_list")]
    public List<HonorMemberInfo>? StrongNewbieList { get; init; }

    /// <summary>
    /// 快乐之源（仅 type 为 emotion 或 all 时有数据）
    /// </summary>
    [JsonPropertyName("emotion_list")]
    public List<HonorMemberInfo>? EmotionList { get; init; }
}

/// <summary>
/// 群荣誉成员信息
/// </summary>
public record HonorMemberInfo
{
    /// <summary>
    /// QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; init; } = string.Empty;

    /// <summary>
    /// 头像 URL
    /// </summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    /// <summary>
    /// 持续天数（仅当前龙王）
    /// </summary>
    [JsonPropertyName("day_count")]
    public int DayCount { get; init; }

    /// <summary>
    /// 荣誉描述（历史荣誉列表）
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
