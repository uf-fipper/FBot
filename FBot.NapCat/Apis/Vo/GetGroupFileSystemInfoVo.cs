using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupFileSystemInfoVo
{
    [JsonPropertyName("file_count")]
    public int FileCount { get; set; }

    [JsonPropertyName("limit_count")]
    public int LimitCount { get; set; }

    [JsonPropertyName("used_space")]
    public long UsedSpace { get; set; }

    [JsonPropertyName("total_space")]
    public long TotalSpace { get; set; }
}
