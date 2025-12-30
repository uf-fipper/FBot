using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Notices;

/// <summary>
/// 群文件上传通知事件，表示有成员在群中上传了文件。
/// 对应 <c>notice_type=group_upload</c>。
/// </summary>
public class GroupUploadNoticeEvent : NoticeBase
{
    /// <summary>
    /// 群号。
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 发送者 QQ 号。
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 文件信息。
    /// </summary>
    [JsonPropertyName("file")]
    public FileInfo File { get; set; } = null!;
}

/// <summary>
/// 群文件信息。
/// </summary>
public class FileInfo
{
    /// <summary>
    /// 文件 ID。
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// 文件名。
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// 文件大小（字节数）。
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; set; }

    /// <summary>
    /// busid（目前不清楚有什么作用）。
    /// </summary>
    [JsonPropertyName("busid")]
    public long Busid { get; set; }
}
