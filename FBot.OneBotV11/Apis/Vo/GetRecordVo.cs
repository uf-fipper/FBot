using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取语音响应数据
/// </summary>
public record GetRecordVo
{
    /// <summary>
    /// 转换后的语音文件路径，如 /home/somebody/cqhttp/data/record/0B38145AA44505000B38145AA4450500.mp3
    /// </summary>
    [JsonPropertyName("file")]
    public string File { get; init; } = string.Empty;
}
