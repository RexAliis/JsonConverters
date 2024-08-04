using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TupleJsonConverters
{
    public abstract class ExtendedJsonConverter<TypeToConvert> : JsonConverter<TypeToConvert>
    {
        protected static T GetNextValue<T>(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            _ = reader.Read();
            return options.GetConverter(typeof(T)) is JsonConverter<T> converter
            ? converter.Read(ref reader, typeToConvert, options)!
            : JsonSerializer.Deserialize<T>(ref reader, options)!;
        }
        protected static void WriteValue<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (options.GetConverter(typeof(T)) is JsonConverter<T> converter) converter.Write(writer, value, options);
            else JsonSerializer.Serialize(writer, value, options);
        }
    }
}
