using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 获取语音请求参数
/// </summary>
public record GetRecordDto
{
    /// <summary>
    /// 收到的语音文件名（消息段的 file 参数），如 0B38145AA44505000B38145AA4450500.silk
    /// </summary>
    [JsonPropertyName("file")]
    public required string File { get; set; }

    /// <summary>
    /// 要转换到的格式，目前支持 mp3、amr、wma、m4a、spx、ogg、wav、flac
    /// </summary>
    [JsonPropertyName("out_format")]
    public required string OutFormat { get; set; }
}
