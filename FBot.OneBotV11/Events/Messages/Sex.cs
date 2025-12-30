using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Sex
{
    /// <summary>
    /// 男性。
    /// </summary>
    [JsonStringEnumMemberName("male")]
    Male,

    /// <summary>
    /// 女性。
    /// </summary>
    [JsonStringEnumMemberName("female")]
    Female,

    /// <summary>
    /// 未知/未指定。
    /// </summary>
    [JsonStringEnumMemberName("unknown")]
    Unknown,
}
