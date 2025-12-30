using System.Text.Json;
using System.Text.Json.Serialization;

namespace FBot.NapCat.Apis.Shared;

[JsonConverter(typeof(StringOrIntegerJsonConverter))]
public class StringOrInteger
{
    public StringOrInteger(string value, bool isNumber = false)
    {
        _value = value;
        TokenType = isNumber ? JsonTokenType.Number : JsonTokenType.String;
    }

    public StringOrInteger(long value)
    {
        _value = value;
        TokenType = JsonTokenType.Number;
    }

    private readonly object _value;

    public readonly JsonTokenType TokenType;

    public override string ToString()
    {
        return _value.ToString()!;
    }

    public string GetString()
    {
        return _value.ToString()!;
    }

    public int GetInt()
    {
        return int.Parse(_value.ToString()!);
    }

    public long GetLong()
    {
        return long.Parse(_value.ToString()!);
    }

    public decimal GetDecimal()
    {
        return decimal.Parse(_value.ToString()!);
    }

    public static implicit operator StringOrInteger(string value) => new(value);

    public static implicit operator StringOrInteger(int value) => new(value);

    public static implicit operator StringOrInteger(long value) => new(value);
}

public class StringOrIntegerJsonConverter : JsonConverter<StringOrInteger>
{
    public override StringOrInteger? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string stringValue = reader.GetString()!;
            return new StringOrInteger(stringValue);
        }
        else if (reader.TokenType == JsonTokenType.Number)
        {
            if (reader.TryGetInt64(out long longValue))
            {
                return new StringOrInteger(longValue);
            }
            // 判断如果是大整数，用字符串读
            var newReader = reader;
            var nString = JsonSerializer.Deserialize<JsonElement>(ref newReader).ToString();
            if (nString.Contains('.'))
            {
                throw new JsonException("Invalid JSON token type for StringOrInteger.");
            }
            return new StringOrInteger(nString, true);
        }
        else
        {
            throw new JsonException("Invalid JSON token type for StringOrInteger.");
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        StringOrInteger value,
        JsonSerializerOptions options
    )
    {
        if (value.TokenType == JsonTokenType.String)
        {
            writer.WriteStringValue(value.ToString());
        }
        else
        {
            writer.WriteRawValue(value.ToString());
        }
    }
}
