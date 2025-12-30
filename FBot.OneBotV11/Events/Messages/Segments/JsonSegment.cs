using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class JsonSegment : Segment<JsonSegmentData> { }

public class JsonSegmentData
{
    [JsonPropertyName("data")]
    public required string Data { get; set; }
}
