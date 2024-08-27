using JsonSerialization.Nullability;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
    internal sealed class OptionalJsonConverter<T> : JsonConverter<Optional<T>>
    {
		public override bool HandleNull => true;
		public override Optional<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
			if (reader.TokenType == JsonTokenType.Null)
			{
				return new(default!);
			};

			T value = JsonSerializer.Deserialize<T>(ref reader, options) ?? throw new JsonException();
			return new(value);
        }
        public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options)
        {
			if (value.IsUndefined)
			{
				return;
			}
			
			if(value.IsNull)
			{
				writer.WriteNullValue();
				return;
			}
			
			JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}
