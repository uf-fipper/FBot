using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Apis.Dto;

/// <summary>
/// 获取群荣誉信息请求参数
/// </summary>
public record GetGroupHonorInfoDto
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    /// <summary>
    /// 要获取的群荣誉类型，可传入 talkative、performer、legend、strong_newbie、emotion 以分别获取单个类型的群荣誉数据，或传入 all 获取所有数据
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
