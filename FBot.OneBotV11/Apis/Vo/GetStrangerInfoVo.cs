using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取陌生人信息响应数据
/// </summary>
public record GetStrangerInfoVo
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
    /// 性别，male 或 female 或 unknown
    /// </summary>
    [JsonPropertyName("sex")]
    public string Sex { get; init; } = string.Empty;

    /// <summary>
    /// 年龄
    /// </summary>
    [JsonPropertyName("age")]
    public int Age { get; init; }
}
