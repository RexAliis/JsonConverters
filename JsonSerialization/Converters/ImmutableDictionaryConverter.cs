
using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
	/// <summary>
	/// Converts a <see cref="ImmutableDictionary{TKey, TValue}"/> to or from JSON.
	/// </summary>
    public sealed class ImmutableDictionaryConverter : JsonConverterFactory
    {
		/// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert)
        {
            ArgumentNullException.ThrowIfNull(typeToConvert);
            return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(ImmutableDictionary<,>);
        }

		/// <inheritdoc/>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            ArgumentNullException.ThrowIfNull(typeToConvert);
            Type[] arguments = typeToConvert.GetGenericArguments();
            return Activator.CreateInstance(typeof(ImmutableDictionaryJsonConverter<,>).MakeGenericType(arguments)) as JsonConverter ?? throw new InvalidOperationException();
        }
    }
}