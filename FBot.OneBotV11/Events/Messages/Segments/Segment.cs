using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class SegmentTypeConverter : AddPolyTypeConverter<Segment>
{
    protected override string PolyTypeName => "type";

    protected override ICollection<(object, Type)>? GetPolyTypes()
    {
        return
        [
            ("text", typeof(TextSegment)),
            ("face", typeof(FaceSegment)),
            ("image", typeof(ImageSegment)),
            ("record", typeof(RecordSegment)),
            ("video", typeof(VideoSegment)),
            ("at", typeof(AtSegment)),
            ("rps", typeof(RpsSegment)),
            ("dice", typeof(DiceSegment)),
            ("shake", typeof(ShakeSegment)),
            ("poke", typeof(PokeSegment)),
            ("anonymous", typeof(AnonymousSegment)),
            ("share", typeof(ShareSegment)),
            ("contact", typeof(ContactSegment)),
            ("location", typeof(LocationSegment)),
            ("music", typeof(MusicSegment)),
            ("reply", typeof(ReplySegment)),
            ("file", typeof(FileSegment)),
            ("forward", typeof(ForwardSegment)),
            ("node", typeof(DirectNodeSegment)),
            ("xml", typeof(XmlSegment)),
            ("json", typeof(JsonSegment)),
        ];
    }
}

[JsonConverter(typeof(SegmentTypeConverter))]
public class Segment
{
    [JsonPropertyName("type")]
    public OB11SegmentType Type { get; set; }
}

public class Segment<T> : Segment
{
    [JsonPropertyName("data")]
    public required T Data { get; set; }
}
