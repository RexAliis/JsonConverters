using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
	/// <summary>
	/// Converts a <see cref="ImmutableArray{T}"/> to or from JSON.
	/// </summary>
    public sealed class ImmutableArrayConverter : JsonConverterFactory
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type typeToConvert)
        {
            ArgumentNullException.ThrowIfNull(typeToConvert);
            return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(ImmutableArray<>);
        }

        /// <inheritdoc/>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            ArgumentNullException.ThrowIfNull(typeToConvert);
            Type[] arguments = typeToConvert.GetGenericArguments();
            return Activator.CreateInstance(typeof(ImmutableArrayJsonConverter<>).MakeGenericType(arguments)) as JsonConverter ?? throw new InvalidOperationException();
        }
    }
}
