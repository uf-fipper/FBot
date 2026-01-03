using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record DeleteEssenceMsgVo
{
    [JsonPropertyName("errCode")]
    public int ErrCode { get; set; }

    [JsonPropertyName("errMsg")]
    public string ErrMsg { get; set; } = null!;

    [JsonPropertyName("result")]
    public EssenceMsgResult Result { get; set; } = null!;
}
