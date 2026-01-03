using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record OcrImageVo
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    [JsonPropertyName("pt1")]
    public Point Pt1 { get; set; } = null!;

    [JsonPropertyName("pt2")]
    public Point Pt2 { get; set; } = null!;

    [JsonPropertyName("pt3")]
    public Point Pt3 { get; set; } = null!;

    [JsonPropertyName("pt4")]
    public Point Pt4 { get; set; } = null!;

    [JsonPropertyName("charBox")]
    public CharBoxInner[] CharBox { get; set; } = null!;

    [JsonPropertyName("score")]
    public string Score { get; set; } = null!;
}

public record Point
{
    [JsonPropertyName("x")]
    public string X { get; set; } = null!;

    [JsonPropertyName("y")]
    public string Y { get; set; } = null!;
}

public record CharBoxInner
{
    [JsonPropertyName("charText")]
    public string CharText { get; set; } = null!;

    [JsonPropertyName("charBox")]
    public CharBoxDetail CharBox { get; set; } = null!;
}

public record CharBoxDetail
{
    [JsonPropertyName("pt1")]
    public Point Pt1 { get; set; } = null!;

    [JsonPropertyName("pt2")]
    public Point Pt2 { get; set; } = null!;

    [JsonPropertyName("pt3")]
    public Point Pt3 { get; set; } = null!;

    [JsonPropertyName("pt4")]
    public Point Pt4 { get; set; } = null!;
}
