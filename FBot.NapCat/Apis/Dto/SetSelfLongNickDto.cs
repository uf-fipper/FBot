using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 设置长昵称请求
/// </summary>
public record SetSelfLongNickDto
{
    /// <summary>
    /// 长昵称
    /// </summary>
    [JsonPropertyName("longNick")]
    public required string LongNick { get; set; }
}
