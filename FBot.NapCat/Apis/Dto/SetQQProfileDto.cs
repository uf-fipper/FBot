using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置账号信息请求
/// </summary>
public record SetQQProfileDto
{
    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// 个性签名
    /// </summary>
    [JsonPropertyName("personal_note")]
    public string? PersonalNote { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [JsonPropertyName("sex")]
    public int? Sex { get; set; }
}
