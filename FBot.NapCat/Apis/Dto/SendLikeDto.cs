using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 点赞请求
/// </summary>
public record SendLikeDto
{
    /// <summary>
    /// 目标用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }

    /// <summary>
    /// 点赞次数
    /// </summary>
    [JsonPropertyName("times")]
    public int Times { get; set; }
}
