using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class TextSegment : Segment<TextSegmentData>;

public class TextSegmentData
{
    [JsonPropertyName("text")]
    public required string Text { get; set; }
}
