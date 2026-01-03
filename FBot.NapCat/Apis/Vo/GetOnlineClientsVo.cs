using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetOnlineClientsVo
{
    [JsonPropertyName("clients")]
    public object Clients { get; set; } = null!;
}
