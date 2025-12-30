using System.Text.Json.Serialization;
using FBot.NapCat.Apis.Shared;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取推荐好友/群聊卡片
/// </summary>
public record SendArkShareDto
{
    /// <summary>
    /// 群聊ID，与 user_id 二选一
    /// </summary>
    [JsonPropertyName("group_id")]
    public StringOrInteger? GroupId { get; set; }

    /// <summary>
    /// 用户ID，与 group_id 二选一
    /// </summary>
    [JsonPropertyName("user_id")]
    public StringOrInteger? UserId { get; set; }
}
