using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupShutListVo
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = null!;

    [JsonPropertyName("qid")]
    public string Qid { get; set; } = null!;

    [JsonPropertyName("uin")]
    public string Uin { get; set; } = null!;

    [JsonPropertyName("nick")]
    public string Nick { get; set; } = null!;

    [JsonPropertyName("remark")]
    public string Remark { get; set; } = null!;

    [JsonPropertyName("cardType")]
    public int CardType { get; set; }

    [JsonPropertyName("cardName")]
    public string CardName { get; set; } = null!;

    [JsonPropertyName("role")]
    public int Role { get; set; }

    [JsonPropertyName("avatarPath")]
    public string AvatarPath { get; set; } = null!;

    [JsonPropertyName("shutUpTime")]
    public long ShutUpTime { get; set; }

    [JsonPropertyName("isDelete")]
    public bool IsDelete { get; set; }

    [JsonPropertyName("isSpecialConcerned")]
    public bool IsSpecialConcerned { get; set; }

    [JsonPropertyName("isSpecialShield")]
    public bool IsSpecialShield { get; set; }

    [JsonPropertyName("isRobot")]
    public bool IsRobot { get; set; }

    [JsonPropertyName("groupHonor")]
    public Dictionary<int, int> GroupHonor { get; set; } = null!;

    [JsonPropertyName("memberRealLevel")]
    public int MemberRealLevel { get; set; }

    [JsonPropertyName("memberLevel")]
    public int MemberLevel { get; set; }

    [JsonPropertyName("globalGroupLevel")]
    public int GlobalGroupLevel { get; set; }

    [JsonPropertyName("globalGroupPoint")]
    public int GlobalGroupPoint { get; set; }

    [JsonPropertyName("memberTitleId")]
    public int MemberTitleId { get; set; }

    [JsonPropertyName("memberSpecialTitle")]
    public string MemberSpecialTitle { get; set; } = null!;

    [JsonPropertyName("specialTitleExpireTime")]
    public string SpecialTitleExpireTime { get; set; } = null!;

    [JsonPropertyName("userShowFlag")]
    public int UserShowFlag { get; set; }

    [JsonPropertyName("userShowFlagNew")]
    public int UserShowFlagNew { get; set; }

    [JsonPropertyName("richFlag")]
    public int RichFlag { get; set; }

    [JsonPropertyName("mssVipType")]
    public int MssVipType { get; set; }

    [JsonPropertyName("bigClubLevel")]
    public int BigClubLevel { get; set; }

    [JsonPropertyName("bigClubFlag")]
    public int BigClubFlag { get; set; }

    [JsonPropertyName("autoRemark")]
    public string AutoRemark { get; set; } = null!;

    [JsonPropertyName("creditLevel")]
    public int CreditLevel { get; set; }

    [JsonPropertyName("joinTime")]
    public long JoinTime { get; set; }

    [JsonPropertyName("lastSpeakTime")]
    public long LastSpeakTime { get; set; }

    [JsonPropertyName("memberFlag")]
    public int MemberFlag { get; set; }

    [JsonPropertyName("memberFlagExt")]
    public int MemberFlagExt { get; set; }

    [JsonPropertyName("memberMobileFlag")]
    public int MemberMobileFlag { get; set; }

    [JsonPropertyName("memberFlagExt2")]
    public int MemberFlagExt2 { get; set; }

    [JsonPropertyName("isSpecialShielded")]
    public bool IsSpecialShielded { get; set; }

    [JsonPropertyName("cardNameId")]
    public int CardNameId { get; set; }
}
