using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class ForwardSegment : Segment<ForwardSegmentData> { }

public class ForwardSegmentData
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
}
