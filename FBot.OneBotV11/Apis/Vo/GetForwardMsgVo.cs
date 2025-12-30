using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取合并转发消息响应数据
/// </summary>
public record GetForwardMsgVo
{
    /// <summary>
    /// 消息内容，使用消息的数组格式表示，数组中的消息段全部为 node 消息段
    /// </summary>
    [JsonPropertyName("message")]
    public Message? Message { get; init; }
}
