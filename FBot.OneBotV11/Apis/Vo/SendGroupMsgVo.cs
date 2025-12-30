using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

public class SendGroupMsgVo
{
    /// <summary>
    /// 消息 ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public long MessageId { get; set; }
}
