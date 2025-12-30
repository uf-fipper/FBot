using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 发送消息请求参数
/// </summary>
public record SendMsgDto
{
    /// <summary>
    /// 消息类型，支持 private、group，分别对应私聊、群组
    /// </summary>
    [JsonPropertyName("message_type")]
    public required SendMsgDtoMessageType MessageType { get; set; }

    /// <summary>
    /// 对方 QQ 号（消息类型为 private 时需要）
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// 群号（消息类型为 group 时需要）
    /// </summary>
    [JsonPropertyName("group_id")]
    public long? GroupId { get; set; }

    /// <summary>
    /// 要发送的内容
    /// </summary>
    [JsonPropertyName("message")]
    public required Message Message { get; set; }
}

/// <summary>
/// 消息类型枚举
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SendMsgDtoMessageType
{
    /// <summary>
    /// 私聊
    /// </summary>
    [JsonStringEnumMemberName("private")]
    Private,

    /// <summary>
    /// 群组
    /// </summary>
    [JsonStringEnumMemberName("group")]
    Group,
}
