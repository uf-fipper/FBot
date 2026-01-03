using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupFilesByFolderVo
{
    [JsonPropertyName("files")]
    public GroupFile[] Files { get; set; } = null!;

    [JsonPropertyName("folders")]
    public GroupFolder[] Folders { get; set; } = null!;
}
