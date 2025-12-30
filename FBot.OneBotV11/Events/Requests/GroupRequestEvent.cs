using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Requests;

/// <summary>
/// 加群请求/邀请事件，表示有用户申请加群或邀请机器人入群。
/// 对应 <c>request_type=group</c>。
/// 需要通过快速操作来同意或拒绝此请求/邀请。
/// </summary>
public class GroupRequestEvent : RequestBase
{
    /// <summary>
    /// 请求子类型，表示加群请求或邀请登录号入群。
    /// </summary>
    [JsonPropertyName("sub_type")]
    public GroupRequestSubType SubType { get; set; }

    /// <summary>
    /// 群号。
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 发送请求的 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 验证信息。
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; } = null!;
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GroupRequestSubType
{
    /// <summary>
    /// 加群请求。
    /// </summary>
    [JsonStringEnumMemberName("add")]
    Add,

    /// <summary>
    /// 邀请登录号入群。
    /// </summary>
    [JsonStringEnumMemberName("invite")]
    Invite,
}
