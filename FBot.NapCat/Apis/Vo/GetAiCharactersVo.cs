using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Vo;

public record GetAiCharactersVo
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("characters")]
    public AiCharacter[] Characters { get; set; } = null!;
}

public record AiCharacter
{
    [JsonPropertyName("character_id")]
    public string CharacterId { get; set; } = null!;

    [JsonPropertyName("character_name")]
    public string CharacterName { get; set; } = null!;

    [JsonPropertyName("preview_url")]
    public string PreviewUrl { get; set; } = null!;
}
