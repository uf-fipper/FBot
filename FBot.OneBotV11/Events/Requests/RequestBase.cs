using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Requests;

/// <summary>
/// 多态转换器：根据 <c>request_type</c> 字段决定具体的请求事件类型。
/// </summary>
public class RequestBaseTypeConverter : AddPolyTypeConverter<RequestBase>
{
    protected override string PolyTypeName => "request_type";

    protected override ICollection<(object, Type)>? GetPolyTypes()
    {
        return [("friend", typeof(FriendRequestEvent)), ("group", typeof(GroupRequestEvent))];
    }
}

/// <summary>
/// OneBot v11 请求事件基类，表示需要处理的各类请求。
/// 对应 <c>post_type=request</c> 事件。
/// 包括加好友请求、加群请求/邀请等，需要机器人进行同意/拒绝等处理。
/// </summary>
[JsonConverter(typeof(RequestBaseTypeConverter))]
public class RequestBase : OneBotV11Event
{
    /// <summary>
    /// 请求类型。
    /// </summary>
    [JsonPropertyName("request_type")]
    public RequestType RequestType { get; set; }

    /// <summary>
    /// 请求 flag，在调用处理请求的 API 时需要传入。
    /// </summary>
    [JsonPropertyName("flag")]
    public string Flag { get; set; } = null!;
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RequestType
{
    /// <summary>
    /// 加好友请求。
    /// </summary>
    [JsonStringEnumMemberName("friend")]
    Friend,

    /// <summary>
    /// 加群请求/邀请。
    /// </summary>
    [JsonStringEnumMemberName("group")]
    Group,
}
