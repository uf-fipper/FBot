using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupRootFilesVo
{
    [JsonPropertyName("files")]
    public GroupFile[] Files { get; set; } = null!;

    [JsonPropertyName("folders")]
    public GroupFolder[] Folders { get; set; } = null!;
}

public record GroupFile
{
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = null!;

    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = null!;

    [JsonPropertyName("busid")]
    public int Busid { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }

    [JsonPropertyName("upload_time")]
    public long UploadTime { get; set; }

    [JsonPropertyName("dead_time")]
    public long DeadTime { get; set; }

    [JsonPropertyName("modify_time")]
    public long ModifyTime { get; set; }

    [JsonPropertyName("download_times")]
    public int DownloadTimes { get; set; }

    [JsonPropertyName("uploader")]
    public long Uploader { get; set; }

    [JsonPropertyName("uploader_name")]
    public string UploaderName { get; set; } = null!;
}

public record GroupFolder
{
    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }

    [JsonPropertyName("folder_id")]
    public string FolderId { get; set; } = null!;

    [JsonPropertyName("folder")]
    public string Folder { get; set; } = null!;

    [JsonPropertyName("folder_name")]
    public string FolderName { get; set; } = null!;

    [JsonPropertyName("create_time")]
    public string CreateTime { get; set; } = null!;

    [JsonPropertyName("creator")]
    public string Creator { get; set; } = null!;

    [JsonPropertyName("creator_name")]
    public string CreatorName { get; set; } = null!;

    [JsonPropertyName("total_file_count")]
    public string TotalFileCount { get; set; } = null!;
}
