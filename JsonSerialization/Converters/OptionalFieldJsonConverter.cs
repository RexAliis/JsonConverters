using JsonSerialization.Nullability;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
	internal sealed class OptionalFieldJsonConverter : JsonConverter<Optional>
	{
		public override bool HandleNull => true;
		public override Optional Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => new();
		public override void Write(Utf8JsonWriter writer, Optional value, JsonSerializerOptions options)
		{
			if(!value.IsUndefined)
			{
				writer.WriteNullValue();
			}
		}
	}
}
