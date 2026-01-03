using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取好友消息历史请求
/// </summary>
public record GetFriendMsgHistoryDto
{
    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public required StringOrInteger UserId { get; set; }

    /// <summary>
    /// 消息序号
    /// </summary>
    [JsonPropertyName("message_seq")]
    public required StringOrInteger MessageSeq { get; set; }

    /// <summary>
    /// 消息数量
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// 是否逆序
    /// </summary>
    [JsonPropertyName("reverse_order")]
    public bool ReverseOrder { get; set; }
}
