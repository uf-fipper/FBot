using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record CreateGroupFileFolderVo
{
    [JsonPropertyName("result")]
    public CreateFolderResult Result { get; set; } = null!;

    [JsonPropertyName("groupItem")]
    public GroupFolderItem GroupItem { get; set; } = null!;
}

public record CreateFolderResult
{
    [JsonPropertyName("retCode")]
    public int RetCode { get; set; }

    [JsonPropertyName("retMsg")]
    public string RetMsg { get; set; } = null!;

    [JsonPropertyName("clientWording")]
    public string ClientWording { get; set; } = null!;
}

public record GroupFolderItem
{
    [JsonPropertyName("peerId")]
    public string PeerId { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("folderInfo")]
    public FolderInfo FolderInfo { get; set; } = null!;
}

public record FolderInfo
{
    [JsonPropertyName("folderId")]
    public string FolderId { get; set; } = null!;

    [JsonPropertyName("parentFolderId")]
    public string ParentFolderId { get; set; } = null!;

    [JsonPropertyName("folderName")]
    public string FolderName { get; set; } = null!;

    [JsonPropertyName("createTime")]
    public long CreateTime { get; set; }

    [JsonPropertyName("modifyTime")]
    public long ModifyTime { get; set; }

    [JsonPropertyName("createUin")]
    public string CreateUin { get; set; } = null!;

    [JsonPropertyName("creatorName")]
    public string CreatorName { get; set; } = null!;

    [JsonPropertyName("totalFileCount")]
    public string TotalFileCount { get; set; } = null!;

    [JsonPropertyName("modifyUin")]
    public string ModifyUin { get; set; } = null!;

    [JsonPropertyName("modifyName")]
    public string ModifyName { get; set; } = null!;

    [JsonPropertyName("usedSpace")]
    public string UsedSpace { get; set; } = null!;
}
