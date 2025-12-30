using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OB11SegmentType
{
    [JsonStringEnumMemberName("text")]
    Text,

    [JsonStringEnumMemberName("face")]
    Face,

    [JsonStringEnumMemberName("image")]
    Image,

    [JsonStringEnumMemberName("record")]
    Record,

    [JsonStringEnumMemberName("video")]
    Video,

    [JsonStringEnumMemberName("at")]
    At,

    [JsonStringEnumMemberName("rps")]
    Rps,

    [JsonStringEnumMemberName("dice")]
    Dice,

    [JsonStringEnumMemberName("shake")]
    Shake,

    [JsonStringEnumMemberName("poke")]
    Poke,

    [JsonStringEnumMemberName("anonymous")]
    Anonymous,

    [JsonStringEnumMemberName("share")]
    Share,

    [JsonStringEnumMemberName("contact")]
    Contact,

    [JsonStringEnumMemberName("location")]
    Location,

    [JsonStringEnumMemberName("music")]
    Music,

    [JsonStringEnumMemberName("music_custom")]
    MusicCustom,

    [JsonStringEnumMemberName("reply")]
    Reply,

    [JsonStringEnumMemberName("forward")]
    Forward,

    [JsonStringEnumMemberName("node")]
    Node,

    [JsonStringEnumMemberName("xml")]
    Xml,

    [JsonStringEnumMemberName("json")]
    Json,

    [JsonStringEnumMemberName("file")]
    File,
}
