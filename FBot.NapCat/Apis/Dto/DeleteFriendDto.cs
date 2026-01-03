using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 删除好友请求
/// </summary>
public record DeleteFriendDto
{
    /// <summary>
    /// 操作者用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }

    /// <summary>
    /// 要删除的好友ID
    /// </summary>
    [JsonPropertyName("friend_id")]
    public required StringOrInteger FriendId { get; set; }

    /// <summary>
    /// 是否临时屏蔽
    /// </summary>
    [JsonPropertyName("temp_block")]
    public bool TempBlock { get; set; }

    /// <summary>
    /// 是否双向删除
    /// </summary>
    [JsonPropertyName("temp_both_del")]
    public bool TempBothDel { get; set; }
}
