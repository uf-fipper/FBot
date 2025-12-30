using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class FileSegment : Segment<FileSegmentData> { }

public class FileSegmentData
{
    [JsonPropertyName("file")]
    public string File { get; set; } = null!;
}
