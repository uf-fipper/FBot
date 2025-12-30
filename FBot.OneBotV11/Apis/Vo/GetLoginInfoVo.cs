using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

/// <summary>
/// 获取登录号信息响应数据
/// </summary>
public record GetLoginInfoVo
{
    /// <summary>
    /// QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    /// <summary>
    /// QQ 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; init; } = string.Empty;
}
