using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetFriendsWithCategoryVo
{
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [JsonPropertyName("categorySortId")]
    public int CategorySortId { get; set; }

    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; } = null!;

    [JsonPropertyName("categoryMbCount")]
    public int CategoryMbCount { get; set; }

    [JsonPropertyName("onlineCount")]
    public int OnlineCount { get; set; }

    [JsonPropertyName("buddyList")]
    public Buddy[] BuddyList { get; set; } = null!;
}

public record Buddy
{
    [JsonPropertyName("qid")]
    public string Qid { get; set; } = null!;

    [JsonPropertyName("longNick")]
    public string LongNick { get; set; } = null!;

    [JsonPropertyName("birthday_year")]
    public int BirthdayYear { get; set; }

    [JsonPropertyName("birthday_month")]
    public int BirthdayMonth { get; set; }

    [JsonPropertyName("birthday_day")]
    public int BirthdayDay { get; set; }

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("sex")]
    public string Sex { get; set; } = null!;

    [JsonPropertyName("eMail")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("phoneNum")]
    public string PhoneNum { get; set; } = null!;

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [JsonPropertyName("richTime")]
    public long RichTime { get; set; }

    [JsonPropertyName("richBuffer")]
    public object RichBuffer { get; set; } = null!;

    [JsonPropertyName("uid")]
    public string Uid { get; set; } = null!;

    [JsonPropertyName("uin")]
    public string Uin { get; set; } = null!;

    [JsonPropertyName("nick")]
    public string Nick { get; set; } = null!;

    [JsonPropertyName("remark")]
    public string Remark { get; set; } = null!;

    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = null!;

    [JsonPropertyName("level")]
    public int Level { get; set; }
}
