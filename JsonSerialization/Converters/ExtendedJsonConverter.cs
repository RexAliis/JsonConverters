using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
    [SuppressMessage("Design", "CA1062: Validate arguments of public methods", Justification = "Instances should be handled only by the JsonSerializer")]
    public abstract class ExtendedJsonConverter<TTypeToConvert> : JsonConverter<TTypeToConvert>
    {
        protected static T ReadNext<T>(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            _ = reader.Read();
            return Read<T>(ref reader, typeToConvert, options);
        }

        protected static T Read<T>(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return options.GetConverter(typeof(T)) is JsonConverter<T> converter
            ? converter.Read(ref reader, typeToConvert, options)!
            : JsonSerializer.Deserialize<T>(ref reader, options)!;
        }

        protected static void Write<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (options.GetConverter(typeof(T)) is JsonConverter<T> converter)
			{
				converter.Write(writer, value, options);
			}
			else
			{
				JsonSerializer.Serialize(writer, value, options);
			}
		}
        
        protected static void WriteAsPropertyName<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options) where T : notnull
        {
            if (options.GetConverter(typeof(T)) is JsonConverter<T> converter)
			{
				converter.WriteAsPropertyName(writer, value, options);
			}
			else
			{
				JsonSerializer.Serialize(writer, value, options);
			}
		}
    }
}
