using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 获取合并转发消息请求参数
/// </summary>
public record GetForwardMsgDto
{
    /// <summary>
    /// 合并转发 ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }
}
