using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages;

/// <summary>
/// 群内发送者信息，包含群身份相关字段（如 role、title 等）。
/// </summary>
public class GroupSender
{
    /// <summary>
    /// 发送者 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// 昵称。
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; } = null!;

    /// <summary>
    /// 性别。
    /// </summary>
    [JsonPropertyName("sex")]
    public Sex? Sex { get; set; }

    /// <summary>
    /// 年龄（可能不存在）。
    /// </summary>
    [JsonPropertyName("age")]
    public int? Age { get; set; }

    /// <summary>
    /// 群名片/备注。
    /// </summary>
    [JsonPropertyName("card")]
    public string? Card { get; set; }

    /// <summary>
    /// 地区。
    /// </summary>
    [JsonPropertyName("area")]
    public string? Area { get; set; }

    /// <summary>
    /// 成员等级（客户端返回，含义视平台）。
    /// </summary>
    [JsonPropertyName("level")]
    public int? Level { get; set; }

    /// <summary>
    /// 角色：owner/admin/member。
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// 专属头衔（可能为空）。
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
