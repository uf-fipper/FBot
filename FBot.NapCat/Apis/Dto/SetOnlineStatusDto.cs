using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置在线状态请求
/// </summary>
public record SetOnlineStatusDto
{
    /// <summary>
    /// 在线状态数据
    /// </summary>
    [JsonPropertyName("data")]
    public required OnlineStatusData Data { get; set; }
}

/// <summary>
/// 在线状态数据
/// </summary>
public record OnlineStatusData
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// 扩展状态
    /// </summary>
    [JsonPropertyName("ext_status")]
    public int ExtStatus { get; set; }

    /// <summary>
    /// 电池状态
    /// </summary>
    [JsonPropertyName("battery_status")]
    public int BatteryStatus { get; set; }
}
