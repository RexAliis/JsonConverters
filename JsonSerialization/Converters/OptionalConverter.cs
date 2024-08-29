using JsonSerialization.Nullability;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
	/// <summary>
	/// Converts a <see cref="Optional{T}"/> to or from JSON.
	/// </summary>
	public sealed class OptionalConverter : JsonConverterFactory
	{
		/// <inheritdoc/>
		public override bool CanConvert(Type typeToConvert)
		{
			ArgumentNullException.ThrowIfNull(typeToConvert);
			return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);
		}

		/// <inheritdoc/>
		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		{
			ArgumentNullException.ThrowIfNull(typeToConvert);
			Type[] arguments = typeToConvert.GetGenericArguments();
			return Activator.CreateInstance(typeof(OptionalJsonConverter<>).MakeGenericType(arguments)) as JsonConverter ?? throw new InvalidOperationException();
		}
	}
}
