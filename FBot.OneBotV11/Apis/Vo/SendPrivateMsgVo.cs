using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

public class SendPrivateMsgVo
{
    [JsonPropertyName("message_id")]
    public long MessageId { get; set; }
}
