using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class AnonymousSegment : Segment<AnonymousSegmentData> { }

public class AnonymousSegmentData
{
    [JsonPropertyName("ignore")]
    public int? Ignore { get; set; }
}
