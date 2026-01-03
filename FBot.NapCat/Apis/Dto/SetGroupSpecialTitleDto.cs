using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置群成员专属头衔请求
/// </summary>
public record SetGroupSpecialTitleDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

    /// <summary>
    /// 成员用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }

    /// <summary>
    /// 专属头衔
    /// </summary>
    [JsonPropertyName("special_title")]
    public required string SpecialTitle { get; set; }
}
