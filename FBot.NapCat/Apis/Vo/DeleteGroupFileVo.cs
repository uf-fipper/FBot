using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record DeleteGroupFileVo
{
    [JsonPropertyName("result")]
    public int Result { get; set; }

    [JsonPropertyName("errMsg")]
    public string ErrMsg { get; set; } = null!;

    [JsonPropertyName("transGroupFileResult")]
    public TransGroupFileResult TransGroupFileResult { get; set; } = null!;
}

public record TransGroupFileResult
{
    [JsonPropertyName("result")]
    public CreateFolderResult Result { get; set; } = null!;

    [JsonPropertyName("successFileIdList")]
    public string[] SuccessFileIdList { get; set; } = null!;

    [JsonPropertyName("failFileIdList")]
    public string[] FailFileIdList { get; set; } = null!;
}
