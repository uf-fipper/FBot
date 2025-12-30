using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Vo;

public class BaseResponseVo
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public BaseResponseVoStatus Status { get; set; }

    [JsonPropertyName("retcode")]
    public int Retcode { get; set; }

    /// <summary>
    /// 如果是 WebSocket 请求，则会带上 Echo
    /// </summary>
    [JsonPropertyName("echo")]
    public Guid Echo { get; set; }
}

public class BaseResponseVo<T> : BaseResponseVo
{
    [JsonPropertyName("data")]
    public T Data { get; set; } = default!;
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BaseResponseVoStatus
{
    /// <summary>
    /// 操作成功
    /// </summary>
    [JsonStringEnumMemberName("ok")]
    Ok,

    /// <summary>
    /// 请求已提交异步处理
    /// </summary>
    [JsonStringEnumMemberName("async")]
    Async,

    /// <summary>
    /// 操作失败
    /// </summary>
    [JsonStringEnumMemberName("failed")]
    Failed,
}
