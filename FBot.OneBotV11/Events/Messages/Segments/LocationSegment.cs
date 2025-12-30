using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class LocationSegment : Segment<LocationSegmentData> { }

public class LocationSegmentData
{
    [JsonPropertyName("lat")]
    public required string Lat { get; set; }

    [JsonPropertyName("lon")]
    public required string Lon { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }
}
