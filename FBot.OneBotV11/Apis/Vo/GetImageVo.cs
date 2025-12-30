using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取图片响应数据
/// </summary>
public record GetImageVo
{
    /// <summary>
    /// 下载后的图片文件路径，如 /home/somebody/cqhttp/data/image/6B4DE3DFD1BD271E3297859D41C530F5.jpg
    /// </summary>
    [JsonPropertyName("file")]
    public string File { get; set; } = string.Empty;
}
