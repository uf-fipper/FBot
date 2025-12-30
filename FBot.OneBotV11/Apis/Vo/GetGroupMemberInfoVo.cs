using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取群成员信息响应数据
/// </summary>
public record GetGroupMemberInfoVo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; init; }

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
    /// 群名片／备注
    /// </summary>
    [JsonPropertyName("card")]
    public string? Card { get; init; }

    /// <summary>
    /// 性别，male 或 female 或 unknown
    /// </summary>
    [JsonPropertyName("sex")]
    public string Sex { get; init; } = string.Empty;

    /// <summary>
    /// 年龄
    /// </summary>
    [JsonPropertyName("age")]
    public int Age { get; init; }

    /// <summary>
    /// 地区
    /// </summary>
    [JsonPropertyName("area")]
    public string? Area { get; init; }

    /// <summary>
    /// 加群时间戳
    /// </summary>
    [JsonPropertyName("join_time")]
    public int JoinTime { get; init; }

    /// <summary>
    /// 最后发言时间戳
    /// </summary>
    [JsonPropertyName("last_sent_time")]
    public int LastSentTime { get; init; }

    /// <summary>
    /// 成员等级
    /// </summary>
    [JsonPropertyName("level")]
    public string? Level { get; init; }

    /// <summary>
    /// 角色，owner 或 admin 或 member
    /// </summary>
    [JsonPropertyName("role")]
    public string Role { get; init; } = string.Empty;

    /// <summary>
    /// 是否不良记录成员
    /// </summary>
    [JsonPropertyName("unfriendly")]
    public bool Unfriendly { get; init; }

    /// <summary>
    /// 专属头衔
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// 专属头衔过期时间戳
    /// </summary>
    [JsonPropertyName("title_expire_time")]
    public int TitleExpireTime { get; init; }

    /// <summary>
    /// 是否允许修改群名片
    /// </summary>
    [JsonPropertyName("card_changeable")]
    public bool CardChangeable { get; init; }
}
