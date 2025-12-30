using System.Text.Json;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

/// <summary>
/// API 响应基础数据
/// </summary>
public record BaseResponseVo
{
    /// <summary>
    /// 状态
    /// </summary>
    [JsonPropertyName("status")]
    public BaseResponseVoStatus Status { get; set; }

    /// <summary>
    /// 返回码
    /// </summary>
    [JsonPropertyName("retcode")]
    public int Retcode { get; set; }

    /// <summary>
    /// 提示信息
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;

    /// <summary>
    /// 人性化提示
    /// </summary>
    [JsonPropertyName("wording")]
    public string Wording { get; set; } = null!;

    /// <summary>
    /// 如果是 WebSocket 请求，则会带上 Echo
    /// </summary>
    [JsonPropertyName("echo")]
    public Guid Echo { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> ExtensionData { get; set; } = [];
}

/// <summary>
/// 泛型 API 响应数据
/// </summary>
public record BaseResponseVo<T> : BaseResponseVo
{
    /// <summary>
    /// 响应数据
    /// </summary>
    [JsonPropertyName("data")]
    public T Data { get; set; } = default!;
}

/// <summary>
/// API 响应状态枚举
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BaseResponseVoStatus
{
    /// <summary>
    /// 操作成功
    /// </summary>
    [JsonStringEnumMemberName("ok")]
    Ok,

    /// <summary>
    /// 操作失败
    /// </summary>
    [JsonStringEnumMemberName("error")]
    Error,
}
