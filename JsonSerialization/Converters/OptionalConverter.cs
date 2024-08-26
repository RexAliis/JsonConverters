using JsonSerialization.Nullability;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
	public sealed class OptionalConverter : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert)
		{
			ArgumentNullException.ThrowIfNull(typeToConvert);
			return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);
		}
		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		{
			ArgumentNullException.ThrowIfNull(typeToConvert);
			Type[] arguments = typeToConvert.GetGenericArguments();
			return Activator.CreateInstance(typeof(OptionalJsonConverter<>).MakeGenericType(arguments)) as JsonConverter ?? throw new InvalidOperationException();
		}
	}
}
