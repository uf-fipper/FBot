using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 获取图片请求参数
/// </summary>
public record GetImageDto
{
    /// <summary>
    /// 收到的图片文件名（消息段的 file 参数），如 6B4DE3DFD1BD271E3297859D41C530F5.jpg
    /// </summary>
    [JsonPropertyName("file")]
    public required string File { get; set; }
}
