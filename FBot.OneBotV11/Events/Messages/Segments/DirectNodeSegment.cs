using System.Text.Json;
using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events.Messages.Segments;

public class DirectNodeSegment : Segment<BaseNodeSegmentData> { }

[JsonConverter(typeof(BaseNodeSegmentDataConverter))]
public class BaseNodeSegmentData { }

public class DirectNodeSegmentData : BaseNodeSegmentData
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
}

public class CustomNodeSegmentsData : BaseNodeSegmentData
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("nickname")]
    public required string Nickname { get; set; }

    [JsonPropertyName("content")]
    public required Message Content { get; set; }
}

internal class BaseNodeSegmentDataConverter : JsonConverter<BaseNodeSegmentData>
{
    public override BaseNodeSegmentData? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        // 使用 JsonDocument 来解析 JSON 而不移动原始 reader
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        JsonElement root = doc.RootElement;

        // 检查是否存在 "id" 字段
        if (
            root.TryGetProperty("id", out JsonElement idElement)
            && idElement.ValueKind != JsonValueKind.Null
        )
        {
            // 存在 id 字段，反序列化为 DirectNodeSegmentData
            return root.Deserialize<DirectNodeSegmentData>(options);
        }
        else
        {
            // 不存在 id 字段，反序列化为 CustomNodeSegmentsData
            return root.Deserialize<CustomNodeSegmentsData>(options);
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BaseNodeSegmentData value,
        JsonSerializerOptions options
    )
    {
        // 根据实际类型进行序列化
        switch (value)
        {
            case DirectNodeSegmentData directData:
                JsonSerializer.Serialize(writer, directData, options);
                break;
            case CustomNodeSegmentsData customData:
                JsonSerializer.Serialize(writer, customData, options);
                break;
            default:
                throw new JsonException($"Unknown derived type: {value.GetType()}");
        }
    }
}
