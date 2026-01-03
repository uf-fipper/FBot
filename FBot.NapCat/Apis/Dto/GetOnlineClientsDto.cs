using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取在线客户端请求
/// </summary>
public record GetOnlineClientsDto
{
    /// <summary>
    /// 是否不使用缓存
    /// </summary>
    [JsonPropertyName("no_cache")]
    public bool? NoCache { get; set; }
}
