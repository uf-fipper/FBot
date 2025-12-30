using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class AtSegment : Segment<AtSegmentData> { }

public class AtSegmentData
{
    [JsonPropertyName("qq")]
    public required string QQ { get; set; }
}
