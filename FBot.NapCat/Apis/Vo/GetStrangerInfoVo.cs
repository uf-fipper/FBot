using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetStrangerInfoVo
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("uid")]
    public string Uid { get; set; } = null!;

    [JsonPropertyName("uin")]
    public string Uin { get; set; } = null!;

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = null!;

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("qid")]
    public string Qid { get; set; } = null!;

    [JsonPropertyName("qqLevel")]
    public int QqLevel { get; set; }

    [JsonPropertyName("sex")]
    public string Sex { get; set; } = null!;

    [JsonPropertyName("long_nick")]
    public string LongNick { get; set; } = null!;

    [JsonPropertyName("reg_time")]
    public long RegTime { get; set; }

    [JsonPropertyName("is_vip")]
    public bool IsVip { get; set; }

    [JsonPropertyName("is_years_vip")]
    public bool IsYearsVip { get; set; }

    [JsonPropertyName("vip_level")]
    public int VipLevel { get; set; }

    [JsonPropertyName("remark")]
    public string Remark { get; set; } = null!;

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("login_days")]
    public int LoginDays { get; set; }
}
