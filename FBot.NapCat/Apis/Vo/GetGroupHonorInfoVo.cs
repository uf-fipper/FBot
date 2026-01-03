using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupHonorInfoVo
{
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("current_talkative")]
    public HonorMember? CurrentTalkative { get; set; }

    [JsonPropertyName("talkative_list")]
    public HonorMember[] TalkativeList { get; set; } = null!;

    [JsonPropertyName("performer_list")]
    public Performer[] PerformerList { get; set; } = null!;

    [JsonPropertyName("legend_list")]
    public string[] LegendList { get; set; } = null!;

    [JsonPropertyName("emotion_list")]
    public string[] EmotionList { get; set; } = null!;

    [JsonPropertyName("strong_newbie_list")]
    public string[] StrongNewbieList { get; set; } = null!;
}

public record HonorMember
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("avatar")]
    public string Avatar { get; set; } = null!;

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = null!;

    [JsonPropertyName("day_count")]
    public int DayCount { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;
}

public record Performer
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("avatar")]
    public string Avatar { get; set; } = null!;

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;
}
