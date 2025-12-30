using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages;
using FBot.OneBotV11.Events.Metas;
using FBot.OneBotV11.Events.Notices;
using FBot.OneBotV11.Events.Requests;

namespace FBot.OneBotV11.Events;

public class OneBotV11EventJsonConverter : AddPolyTypeConverter<OneBotV11Event>
{
    protected override string PolyTypeName => "post_type";

    protected override ICollection<(object, Type)>? GetPolyTypes()
    {
        return
        [
            ("meta_event", typeof(BaseMetaEvent)),
            ("message", typeof(BaseMessageEvent)),
            ("notice", typeof(NoticeBase)),
            ("request", typeof(RequestBase)),
        ];
    }
}

[JsonConverter(typeof(OneBotV11EventJsonConverter))]
public class OneBotV11Event : IEvent
{
    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("self_id")]
    public long SelfId { get; set; }

    [JsonPropertyName("post_type")]
    public EventType PostType { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EventType
{
    [JsonStringEnumMemberName("meta_event")]
    Meta,

    [JsonStringEnumMemberName("request")]
    Request,

    [JsonStringEnumMemberName("notice")]
    Notice,

    [JsonStringEnumMemberName("message")]
    Message,
}
