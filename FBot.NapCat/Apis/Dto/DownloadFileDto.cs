using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 下载文件请求
/// </summary>
public record DownloadFileDto
{
    /// <summary>
    /// Base64编码的文件数据
    /// </summary>
    [JsonPropertyName("base64")]
    public string? Base64 { get; set; }

    /// <summary>
    /// 文件URL
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// 下载线程数
    /// </summary>
    [JsonPropertyName("thread_count")]
    public int ThreadCount { get; set; }

    /// <summary>
    /// 请求头
    /// </summary>
    [JsonPropertyName("headers")]
    public required string[] Headers { get; set; }

    /// <summary>
    /// 保存文件名
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
