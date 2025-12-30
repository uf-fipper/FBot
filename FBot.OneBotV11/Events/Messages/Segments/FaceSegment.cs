using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class FaceSegment : Segment<FaceSegmentData> { }

public class FaceSegmentData
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
}
