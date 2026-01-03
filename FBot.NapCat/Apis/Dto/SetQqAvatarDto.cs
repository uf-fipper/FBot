using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置QQ头像请求
/// </summary>
public record SetQqAvatarDto
{
    /// <summary>
    /// 文件
    /// </summary>
    [JsonPropertyName("file")]
    public required string File { get; set; }
}
