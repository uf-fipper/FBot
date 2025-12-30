using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class ImageSegment : Segment<ImageSegmentData> { }

public class ImageSegmentData
{
    [JsonPropertyName("file")]
    public required string File { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("cache")]
    public int? Cache { get; set; }

    [JsonPropertyName("proxy")]
    public int? Proxy { get; set; }

    [JsonPropertyName("timeout")]
    public long? Timeout { get; set; }
}
