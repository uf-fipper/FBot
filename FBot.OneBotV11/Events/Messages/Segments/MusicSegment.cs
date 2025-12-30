using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class BaseMusicSegmentDataTypeConverter : AddPolyTypeConverter<BaseMusicSegmentData>
{
    protected override string PolyTypeName => "type";

    protected override ICollection<(object, Type)>? GetPolyTypes()
    {
        return
        [
            ("qq", typeof(MusicSegmentData)),
            ("163", typeof(MusicSegmentData)),
            ("xm", typeof(MusicSegmentData)),
            ("custom", typeof(CustomMusicSegmentData)),
        ];
    }
}

public class MusicSegment : Segment<BaseMusicSegmentData> { }

[JsonConverter(typeof(BaseMusicSegmentDataTypeConverter))]
public class BaseMusicSegmentData
{
    [JsonPropertyName("type")]
    public MusicSegmentDataType Type { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MusicSegmentDataType
{
    [JsonStringEnumMemberName("qq")]
    QQ,

    [JsonStringEnumMemberName("163")]
    NetEase,

    [JsonStringEnumMemberName("xm")]
    Xm,

    [JsonStringEnumMemberName("custom")]
    Custom,
}

public class MusicSegmentData : BaseMusicSegmentData
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}

internal class MusicQQSegmentData : MusicSegmentData { }

internal class Music163SegmentData : MusicSegmentData { }

internal class MusicXmSegmentData : MusicSegmentData { }

public class CustomMusicSegmentData : BaseMusicSegmentData
{
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("audio")]
    public required string Audio { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }
}
