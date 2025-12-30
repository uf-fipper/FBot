using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取消息响应数据
/// </summary>
public record GetMsgVo
{
    /// <summary>
    /// 发送时间
    /// </summary>
    [JsonPropertyName("time")]
    public int Time { get; init; }

    /// <summary>
    /// 消息类型，同消息事件
    /// </summary>
    [JsonPropertyName("message_type")]
    public string MessageType { get; init; } = string.Empty;

    /// <summary>
    /// 消息 ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public int MessageId { get; init; }

    /// <summary>
    /// 消息真实 ID
    /// </summary>
    [JsonPropertyName("real_id")]
    public int RealId { get; init; }

    /// <summary>
    /// 发送人信息，同消息事件
    /// </summary>
    [JsonPropertyName("sender")]
    public SenderInfo? Sender { get; init; }

    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }
}

/// <summary>
/// 发送人信息
/// </summary>
public record SenderInfo
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
    public string? Nickname { get; init; }

    /// <summary>
    /// 群名片／备注
    /// </summary>
    [JsonPropertyName("card")]
    public string? Card { get; init; }

    /// <summary>
    /// 性别，male 或 female 或 unknown
    /// </summary>
    [JsonPropertyName("sex")]
    public string? Sex { get; init; }

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
    /// 成员等级
    /// </summary>
    [JsonPropertyName("level")]
    public string? Level { get; init; }

    /// <summary>
    /// 角色，owner 或 admin 或 member
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; init; }

    /// <summary>
    /// 专属头衔
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }
}
