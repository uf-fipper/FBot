using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record FetchEmojiLikeVo
{
    [JsonPropertyName("result")]
    public int Result { get; set; }

    [JsonPropertyName("errMsg")]
    public string ErrMsg { get; set; } = null!;

    [JsonPropertyName("emojiLikesList")]
    public EmojiLike[] EmojiLikesList { get; set; } = null!;

    [JsonPropertyName("cookie")]
    public string Cookie { get; set; } = null!;

    [JsonPropertyName("isLastPage")]
    public bool IsLastPage { get; set; }

    [JsonPropertyName("isFirstPage")]
    public bool IsFirstPage { get; set; }
}

public record EmojiLike
{
    [JsonPropertyName("tinyId")]
    public string TinyId { get; set; } = null!;

    [JsonPropertyName("nickName")]
    public string NickName { get; set; } = null!;

    [JsonPropertyName("headUrl")]
    public string HeadUrl { get; set; } = null!;
}
