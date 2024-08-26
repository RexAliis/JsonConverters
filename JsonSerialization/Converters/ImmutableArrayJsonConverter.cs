using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;

namespace JsonSerialization.Converters
{
    internal sealed class ImmutableArrayJsonConverter<T> : ExtendedJsonConverter<ImmutableArray<T>>
    {
        public override ImmutableArray<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T[] values = JsonSerializer.Deserialize<T[]>(ref reader, options) ?? throw new JsonException();
            return [.. values];
        }
        public override void Write(Utf8JsonWriter writer, ImmutableArray<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToArray(), options);
        }
    }
}
