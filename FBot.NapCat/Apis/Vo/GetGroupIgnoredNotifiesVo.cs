using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupIgnoredNotifiesVo
{
    [JsonPropertyName("join_requests")]
    public JoinRequest[] JoinRequests { get; set; } = null!;
}
