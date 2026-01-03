using FBot.NapCat.Apis.Shared;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Dto;

/// <summary>
/// 获取群消息历史请求
/// </summary>
public record GetGroupMsgHistoryDto
{
    /// <summary>
    /// 群ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public required StringOrInteger GroupId { get; set; }

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
