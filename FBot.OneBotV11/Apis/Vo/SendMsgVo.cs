using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

public class SendMsgVo
{
    [JsonPropertyName("message_id")]
    public long MessageId { get; set; }
}
