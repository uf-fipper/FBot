using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages;

/// <summary>
/// 私聊/好友发送者信息结构。
/// 部分字段可能缺失（OneBot 会尽最大努力提供）。
/// </summary>
public class FriendSender
{
    /// <summary>
    /// 发送者 QQ 号，可能为空（取决于平台回报）。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// 昵称。
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; } = null!;

    /// <summary>
    /// 性别：male/female/unknown。
    /// </summary>
    [JsonPropertyName("sex")]
    public Sex? Sex { get; set; }

    /// <summary>
    /// 年龄（可能不存在）。
    /// </summary>
    [JsonPropertyName("age")]
    public int? Age { get; set; }
}
