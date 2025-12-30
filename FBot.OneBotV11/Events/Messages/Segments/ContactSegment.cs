using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class ContactSegment : Segment<ContactSegmentData> { }

public class ContactSegmentData
{
    [JsonPropertyName("type")]
    public ContactSegmentDataType Type { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContactSegmentDataType
{
    [JsonStringEnumMemberName("qq")]
    QQ,

    [JsonStringEnumMemberName("group")]
    Group,
}
