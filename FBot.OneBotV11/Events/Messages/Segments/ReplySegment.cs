using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class ReplySegment : Segment<ReplySegmentData> { }

public class ReplySegmentData
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
}
