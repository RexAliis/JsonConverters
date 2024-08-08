using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;

namespace JsonConverters
{
    internal sealed class ImmutableArrayJsonConverter<T> : ExtendedJsonConverter<ImmutableArray<T>>
    {
        public override ImmutableArray<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException();

            List<T> values = [];
            _ = reader.Read();

            while (reader.TokenType != JsonTokenType.EndArray)
            {
                values.Add(GetValue<T>(ref reader, typeToConvert, options));
                _ = reader.Read();
            }

            return [.. values];
        }
        public override void Write(Utf8JsonWriter writer, ImmutableArray<T> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (T item in value)
            {
                WriteValue(writer, item, options);
            }

            writer.WriteEndArray();
        }
    }
}
