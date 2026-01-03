using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetGroupAtAllRemainVo
{
    [JsonPropertyName("can_at_all")]
    public bool CanAtAll { get; set; }

    [JsonPropertyName("remain_at_all_count_for_group")]
    public int RemainAtAllCountForGroup { get; set; }

    [JsonPropertyName("remain_at_all_count_for_uin")]
    public int RemainAtAllCountForUin { get; set; }
}
