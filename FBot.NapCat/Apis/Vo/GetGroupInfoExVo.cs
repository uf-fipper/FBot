using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupInfoExVo
{
    [JsonPropertyName("groupCode")]
    public string GroupCode { get; set; } = null!;

    [JsonPropertyName("resultCode")]
    public int ResultCode { get; set; }

    [JsonPropertyName("extInfo")]
    public GroupExtInfo ExtInfo { get; set; } = null!;
}

public record GroupExtInfo
{
    [JsonPropertyName("groupInfoExtSeq")]
    public int GroupInfoExtSeq { get; set; }

    [JsonPropertyName("reserve")]
    public int Reserve { get; set; }

    [JsonPropertyName("luckyWordId")]
    public string LuckyWordId { get; set; } = null!;

    [JsonPropertyName("lightCharNum")]
    public int LightCharNum { get; set; }

    [JsonPropertyName("luckyWord")]
    public string LuckyWord { get; set; } = null!;

    [JsonPropertyName("starId")]
    public int StarId { get; set; }

    [JsonPropertyName("essentialMsgSwitch")]
    public int EssentialMsgSwitch { get; set; }

    [JsonPropertyName("todoSeq")]
    public int TodoSeq { get; set; }

    [JsonPropertyName("blacklistExpireTime")]
    public long BlacklistExpireTime { get; set; }

    [JsonPropertyName("isLimitGroupRtc")]
    public int IsLimitGroupRtc { get; set; }

    [JsonPropertyName("companyId")]
    public int CompanyId { get; set; }

    [JsonPropertyName("hasGroupCustomPortrait")]
    public int HasGroupCustomPortrait { get; set; }

    [JsonPropertyName("bindGuildId")]
    public string BindGuildId { get; set; } = null!;

    [JsonPropertyName("groupOwnerId")]
    public GroupOwnerId GroupOwnerId { get; set; } = null!;

    [JsonPropertyName("essentialMsgPrivilege")]
    public int EssentialMsgPrivilege { get; set; }

    [JsonPropertyName("msgEventSeq")]
    public string MsgEventSeq { get; set; } = null!;

    [JsonPropertyName("inviteRobotSwitch")]
    public int InviteRobotSwitch { get; set; }

    [JsonPropertyName("gangUpId")]
    public string GangUpId { get; set; } = null!;

    [JsonPropertyName("qqMusicMedalSwitch")]
    public int QqMusicMedalSwitch { get; set; }

    [JsonPropertyName("showPlayTogetherSwitch")]
    public int ShowPlayTogetherSwitch { get; set; }

    [JsonPropertyName("groupFlagPro1")]
    public string? GroupFlagPro1 { get; set; }

    [JsonPropertyName("groupBindGuildIds")]
    public GroupBindGuildIds GroupBindGuildIds { get; set; } = null!;

    [JsonPropertyName("viewedMsgDisappearTime")]
    public string ViewedMsgDisappearTime { get; set; } = null!;

    [JsonPropertyName("groupExtFlameData")]
    public GroupExtFlameData GroupExtFlameData { get; set; } = null!;

    [JsonPropertyName("groupBindGuildSwitch")]
    public int GroupBindGuildSwitch { get; set; }

    [JsonPropertyName("groupAioBindGuildId")]
    public string GroupAioBindGuildId { get; set; } = null!;

    [JsonPropertyName("groupExcludeGuildIds")]
    public GroupExcludeGuildIds GroupExcludeGuildIds { get; set; } = null!;

    [JsonPropertyName("fullGroupExpansionSwitch")]
    public int FullGroupExpansionSwitch { get; set; }

    [JsonPropertyName("fullGroupExpansionSeq")]
    public string FullGroupExpansionSeq { get; set; } = null!;

    [JsonPropertyName("inviteRobotMemberSwitch")]
    public int InviteRobotMemberSwitch { get; set; }

    [JsonPropertyName("inviteRobotMemberExamine")]
    public int InviteRobotMemberExamine { get; set; }

    [JsonPropertyName("groupSquareSwitch")]
    public int GroupSquareSwitch { get; set; }
}

public record GroupOwnerId
{
    [JsonPropertyName("memberUin")]
    public string MemberUin { get; set; } = null!;

    [JsonPropertyName("memberUid")]
    public string MemberUid { get; set; } = null!;

    [JsonPropertyName("memberQid")]
    public string MemberQid { get; set; } = null!;
}

public record GroupBindGuildIds
{
    [JsonPropertyName("guildIds")]
    public string[] GuildIds { get; set; } = null!;
}

public record GroupExtFlameData
{
    [JsonPropertyName("switchState")]
    public int SwitchState { get; set; }

    [JsonPropertyName("state")]
    public int State { get; set; }

    [JsonPropertyName("dayNums")]
    public int[] DayNums { get; set; } = null!;

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("updateTime")]
    public string UpdateTime { get; set; } = null!;

    [JsonPropertyName("isDisplayDayNum")]
    public bool IsDisplayDayNum { get; set; }
}

public record GroupExcludeGuildIds
{
    [JsonPropertyName("guildIds")]
    public string[] GuildIds { get; set; } = null!;
}
