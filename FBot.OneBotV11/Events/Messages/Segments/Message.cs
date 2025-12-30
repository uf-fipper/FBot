namespace FBot.OneBotV11.Events.Messages.Segments;

public class Message : List<Segment>
{
    public Message()
        : base() { }

    public Message(Segment segment)
        : base([segment]) { }

    public Message(IEnumerable<Segment> segments)
        : base(segments) { }

    public static implicit operator Message(Segment segment) => [segment];

    public static implicit operator Message(string segment) =>
        [new TextSegment { Data = new TextSegmentData { Text = segment } }];
}
