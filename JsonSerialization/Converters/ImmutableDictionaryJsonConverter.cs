using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;

namespace JsonSerialization.Converters
{
    internal sealed class ImmutableDictionaryJsonConverter<TKey, TValue> : ExtendedJsonConverter<ImmutableDictionary<TKey, TValue>> where TKey : notnull
    {
        public override ImmutableDictionary<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Dictionary<TKey, TValue> dictionary = JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(ref reader, options) ?? throw new JsonException();
            return dictionary.ToImmutableDictionary();
        }
        public override void Write(Utf8JsonWriter writer, ImmutableDictionary<TKey, TValue> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToDictionary(), options);
        }
    }
}
