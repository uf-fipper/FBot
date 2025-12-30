using System.Text.Json.Serialization;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Apis.Dto;

public class SendMsgDto
{
    [JsonPropertyName("message_type")]
    public required SendMsgDtoMessageType MessageType { get; set; }

    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }

    [JsonPropertyName("group_id")]
    public long? GroupId { get; set; }

    [JsonPropertyName("message")]
    public required Message Message { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SendMsgDtoMessageType
{
    [JsonStringEnumMemberName("private")]
    Private,

    [JsonStringEnumMemberName("group")]
    Group,
}
