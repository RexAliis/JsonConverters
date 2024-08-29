using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
	/// <summary>
	/// Provides an abstract base class that extend the functionality of <see cref="JsonConverter{T}"/>.
	/// </summary>
	/// <typeparam name="TTypeToConvert">The type of object to convert.</typeparam>
    [SuppressMessage("Design", "CA1062: Validate arguments of public methods", Justification = "Instances should be handled only by the JsonSerializer")]
    public abstract class ExtendedJsonConverter<TTypeToConvert> : JsonConverter<TTypeToConvert>
    {
        protected static T ReadNext<T>(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		/// <summary>
		/// Reads the next JSON token and deserializes it to the specified type.
		/// </summary>
		/// <typeparam name="T">The type to deserialize.</typeparam>
		/// <param name="reader">The <see cref="Utf8JsonReader"/> to read.</param>
		/// <param name="typeToConvert">The type of the object to return.</param>
		/// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
		/// <returns>The deserialized object of type <typeparamref name="T"/>.</returns>
        {
            _ = reader.Read();
            return Read<T>(ref reader, typeToConvert, options);
        }

        protected static T Read<T>(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		/// <summary>
		/// Deserializes the current JSON token to the specified type.
		/// </summary>
		/// <typeparam name="T">The type to deserialize.</typeparam>
		/// <param name="reader">The <see cref="Utf8JsonReader"/> to read.</param>
		/// <param name="typeToConvert">The type of the object to return.</param>
		/// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
		/// <returns>The deserialized object of type <typeparamref name="T"/>.</returns>
        {
            return options.GetConverter(typeof(T)) is JsonConverter<T> converter
            ? converter.Read(ref reader, typeToConvert, options)!
            : JsonSerializer.Deserialize<T>(ref reader, options)!;
        }

        protected static void Write<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		/// <summary>
		/// Serializes the specified value to JSON.
		/// </summary>
		/// <typeparam name="T">The type to serialize.</typeparam>
		/// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
		/// <param name="value">The value to convert.</param>
		/// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
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
    }
}
