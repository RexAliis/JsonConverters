using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonConverters
{
    public sealed class ImmutableArrayConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            ArgumentNullException.ThrowIfNull(typeToConvert);
            return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(ImmutableArray<>);
        }
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            ArgumentNullException.ThrowIfNull(typeToConvert);
            Type[] arguments = typeToConvert.GetGenericArguments();
            return Activator.CreateInstance(typeof(ImmutableArrayJsonConverter<>).MakeGenericType(arguments)) as JsonConverter ?? throw new InvalidOperationException();
        }
    }
}
