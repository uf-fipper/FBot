using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetProfileLikeVo
{
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }

    [JsonPropertyName("new_count")]
    public int NewCount { get; set; }

    [JsonPropertyName("new_nearby_count")]
    public int NewNearbyCount { get; set; }

    [JsonPropertyName("last_visit_time")]
    public long LastVisitTime { get; set; }

    [JsonPropertyName("userInfos")]
    public UserInfo[] UserInfos { get; set; } = null!;
}

public record UserInfo
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = null!;

    [JsonPropertyName("src")]
    public int Src { get; set; }

    [JsonPropertyName("latestTime")]
    public long LatestTime { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("giftCount")]
    public int GiftCount { get; set; }

    [JsonPropertyName("customId")]
    public int CustomId { get; set; }

    [JsonPropertyName("lastCharged")]
    public long LastCharged { get; set; }

    [JsonPropertyName("bAvailableCnt")]
    public int BAvailableCnt { get; set; }

    [JsonPropertyName("bTodayVotedCnt")]
    public int BTodayVotedCnt { get; set; }

    [JsonPropertyName("nick")]
    public string Nick { get; set; } = null!;

    [JsonPropertyName("gender")]
    public int Gender { get; set; }

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("isFriend")]
    public bool IsFriend { get; set; }

    [JsonPropertyName("isvip")]
    public bool Isvip { get; set; }

    [JsonPropertyName("isSvip")]
    public bool IsSvip { get; set; }

    [JsonPropertyName("uin")]
    public long Uin { get; set; }
}
