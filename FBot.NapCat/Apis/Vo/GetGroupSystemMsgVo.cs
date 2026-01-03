using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupSystemMsgVo
{
    [JsonPropertyName("InvitedRequest")]
    public InvitedRequest[] InvitedRequests { get; set; } = null!;

    [JsonPropertyName("join_requests")]
    public JoinRequest[] JoinRequests { get; set; } = null!;
}

public record InvitedRequest
{
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = null!;

    [JsonPropertyName("invitor_uin")]
    public string InvitorUin { get; set; } = null!;

    [JsonPropertyName("invitor_nick")]
    public string InvitorNick { get; set; } = null!;

    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = null!;

    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = null!;

    [JsonPropertyName("checked")]
    public bool Checked { get; set; }

    [JsonPropertyName("actor")]
    public string Actor { get; set; } = null!;
}

public record JoinRequest
{
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = null!;

    [JsonPropertyName("requester_uin")]
    public string RequesterUin { get; set; } = null!;

    [JsonPropertyName("requester_nick")]
    public string RequesterNick { get; set; } = null!;

    [JsonPropertyName("group_id")]
    public string GroupId { get; set; } = null!;

    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = null!;

    [JsonPropertyName("checked")]
    public bool Checked { get; set; }

    [JsonPropertyName("actor")]
    public string Actor { get; set; } = null!;
}
