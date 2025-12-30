using System.Text.Json;
using System.Text.Json.Serialization;

namespace FBot.OneBotV11.Events;

public abstract class AddPolyTypeConverter<T> : JsonConverter<T>
{
    protected virtual string PolyTypeName => "$type";

    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(T).IsAssignableFrom(typeToConvert);
    }

    protected virtual ICollection<(object, Type)>? GetPolyTypes() => null;

    public override T? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var jsonElement = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        object? key = null;
        if (jsonElement.TryGetProperty(PolyTypeName, out var key1))
        {
            key = key1.ValueKind switch
            {
                JsonValueKind.String => key1.GetString(),
                JsonValueKind.Number => key1.ToString(),
                _ => null,
            };
        }
        Type distType = typeof(T);
        var polyTypes = GetPolyTypes();
        if (key is not null && polyTypes is not null)
        {
            foreach (var (distKey, type) in polyTypes)
            {
                if (key.Equals(distKey))
                {
                    distType = type;
                    break;
                }
            }
        }

        return (T?)jsonElement.Deserialize(distType, options);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize<object?>(writer, value, options);
    }
}
