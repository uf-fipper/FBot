using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 发送群AI录音请求
/// </summary>
public record SendGroupAiRecordDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

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
