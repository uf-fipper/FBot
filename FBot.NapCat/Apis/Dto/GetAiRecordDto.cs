using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取AI对话记录请求
/// </summary>
public record GetAiRecordDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required string GroupId { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    [JsonPropertyName("character")]
    public required string Character { get; set; }

    /// <summary>
    /// 文本
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }
}
