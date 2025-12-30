using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class XmlSegment : Segment<XmlSegmentData> { }

public class XmlSegmentData
{
    [JsonPropertyName("data")]
    public required string Data { get; set; }
}
