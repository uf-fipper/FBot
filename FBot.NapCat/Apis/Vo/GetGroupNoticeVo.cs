using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GroupNoticeVo
{
    [JsonPropertyName("notice_id")]
    public string NoticeId { get; set; } = null!;

    [JsonPropertyName("sender_id")]
    public int SenderId { get; set; }

    [JsonPropertyName("publish_time")]
    public long PublishTime { get; set; }

    [JsonPropertyName("message")]
    public GroupNoticeMessage Message { get; set; } = null!;
}

public record GroupNoticeMessage
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    [JsonPropertyName("image")]
    public GroupNoticeImage[] Image { get; set; } = null!;
}

public record GroupNoticeImage
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("height")]
    public string Height { get; set; } = null!;

    [JsonPropertyName("width")]
    public string Width { get; set; } = null!;
}
