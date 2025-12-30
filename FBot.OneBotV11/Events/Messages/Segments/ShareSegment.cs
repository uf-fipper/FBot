using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class ShareSegment : Segment<ShareSegmentData> { }

public class ShareSegmentData
{
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }
}
