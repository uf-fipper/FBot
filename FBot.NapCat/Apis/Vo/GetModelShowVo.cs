using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetModelShowVo
{
    [JsonPropertyName("variants")]
    public ModelVariant[] Variants { get; set; } = null!;
}

public record ModelVariant
{
    [JsonPropertyName("model_show")]
    public string ModelShow { get; set; } = null!;

    [JsonPropertyName("need_pay")]
    public bool NeedPay { get; set; }
}
