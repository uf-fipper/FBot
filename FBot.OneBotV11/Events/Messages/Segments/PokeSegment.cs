using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class PokeSegment : Segment<PokeSegmentData> { }

public class PokeSegmentData
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
