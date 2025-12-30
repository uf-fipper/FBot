using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取运行状态响应数据
/// </summary>
public record GetStatusVo
{
    /// <summary>
    /// 当前 QQ 在线，null 表示无法查询到在线状态
    /// </summary>
    [JsonPropertyName("online")]
    public bool? Online { get; init; }

    /// <summary>
    /// 状态符合预期，意味着各模块正常运行、功能正常，且 QQ 在线
    /// </summary>
    [JsonPropertyName("good")]
    public bool Good { get; init; }
}
