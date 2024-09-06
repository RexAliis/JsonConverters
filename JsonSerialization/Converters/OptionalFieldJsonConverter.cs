using JsonSerialization.Nullability;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
	/// <summary>
	/// Converts a <see cref="Optional"/> to or from JSON.
	/// </summary>
	public sealed class OptionalFieldJsonConverter : JsonConverter<Optional>
	{
		/// <inheritdoc/>
		public override bool HandleNull => true;

		/// <inheritdoc/>
		public override Optional Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => new();

		/// <inheritdoc/>
		public override void Write(Utf8JsonWriter writer, Optional value, JsonSerializerOptions options)
		{
			ArgumentNullException.ThrowIfNull(writer);
			if(!value.IsUndefined)
			{
				writer.WriteNullValue();
			}
		}
	}
}
