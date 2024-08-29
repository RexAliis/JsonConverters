using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialization.Converters
{
    internal sealed class TupleJsonConverter<T1> : JsonConverter<Tuple<T1>>
    {
        public override Tuple<T1> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			_ = reader.Read();
			T1 item1 = JsonSerializer.Deserialize<T1>(ref reader, options)!;
            _ = reader.Read();
            return new Tuple<T1>(item1);
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            writer.WriteEndArray();
        }
    }
    internal sealed class TupleJsonConverter<T1, T2> : JsonConverter<Tuple<T1, T2>>
    {
        public override Tuple<T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			_ = reader.Read();
			T1 item1 = JsonSerializer.Deserialize<T1>(ref reader, options)!;
			_ = reader.Read();
			T2 item2 = JsonSerializer.Deserialize<T2>(ref reader, options)!;
            _ = reader.Read();
            return new Tuple<T1, T2>(item1, item2);
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
			JsonSerializer.Serialize(writer, value.Item2, options);
            writer.WriteEndArray();
        }
    }
    internal sealed class TupleJsonConverter<T1, T2, T3> : JsonConverter<Tuple<T1, T2, T3>>
    {
        public override Tuple<T1, T2, T3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			_ = reader.Read();
			T1 item1 = JsonSerializer.Deserialize<T1>(ref reader, options)!;
            _ = reader.Read();
			T2 item2 = JsonSerializer.Deserialize<T2>(ref reader, options)!;
            _ = reader.Read();
			T3 item3 = JsonSerializer.Deserialize<T3>(ref reader, options)!;
            _ = reader.Read();
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            writer.WriteEndArray();
        }
    }
    internal sealed class TupleJsonConverter<T1, T2, T3, T4> : JsonConverter<Tuple<T1, T2, T3, T4>>
    {
        public override Tuple<T1, T2, T3, T4> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			_ = reader.Read();
			T1 item1 = JsonSerializer.Deserialize<T1>(ref reader, options)!;
            _ = reader.Read();
			T2 item2 = JsonSerializer.Deserialize<T2>(ref reader, options)!;
            _ = reader.Read();
			T3 item3 = JsonSerializer.Deserialize<T3>(ref reader, options)!;
            _ = reader.Read();
			T4 item4 = JsonSerializer.Deserialize<T4>(ref reader, options)!;
            _ = reader.Read();
            return new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            writer.WriteEndArray();
        }
    }
    internal sealed class TupleJsonConverter<T1, T2, T3, T4, T5> : JsonConverter<Tuple<T1, T2, T3, T4, T5>>
    {
        public override Tuple<T1, T2, T3, T4, T5> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			_ = reader.Read();
			T1 item1 = JsonSerializer.Deserialize<T1>(ref reader, options)!;
            _ = reader.Read();
			T2 item2 = JsonSerializer.Deserialize<T2>(ref reader, options)!;
            _ = reader.Read();
			T3 item3 = JsonSerializer.Deserialize<T3>(ref reader, options)!;
            _ = reader.Read();
			T4 item4 = JsonSerializer.Deserialize<T4>(ref reader, options)!;
			_ = reader.Read();
            T5 item5 = JsonSerializer.Deserialize<T5>(ref reader, options)!;
            _ = reader.Read();
            return new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            JsonSerializer.Serialize(writer, value.Item5, options);
            writer.WriteEndArray();
        }
    }
    internal sealed class TupleJsonConverter<T1, T2, T3, T4, T5, T6> : JsonConverter<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        public override Tuple<T1, T2, T3, T4, T5, T6> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			_ = reader.Read();
			T1 item1 = JsonSerializer.Deserialize<T1>(ref reader, options)!;
            _ = reader.Read();
			T2 item2 = JsonSerializer.Deserialize<T2>(ref reader, options)!;
            _ = reader.Read();
			T3 item3 = JsonSerializer.Deserialize<T3>(ref reader, options)!;
            _ = reader.Read();
			T4 item4 = JsonSerializer.Deserialize<T4>(ref reader, options)!;
			_ = reader.Read();
            T5 item5 = JsonSerializer.Deserialize<T5>(ref reader, options)!;
            _ = reader.Read();
            T6 item6 = JsonSerializer.Deserialize<T6>(ref reader, options)!;
            _ = reader.Read();
            return new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5, T6> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            JsonSerializer.Serialize(writer, value.Item5, options);
            JsonSerializer.Serialize(writer, value.Item6, options);
            writer.WriteEndArray();
        }
    }
    internal sealed class TupleJsonConverter<T1, T2, T3, T4, T5, T6, T7> : JsonConverter<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        public override Tuple<T1, T2, T3, T4, T5, T6, T7> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			_ = reader.Read();
			T1 item1 = JsonSerializer.Deserialize<T1>(ref reader, options)!;
            _ = reader.Read();
			T2 item2 = JsonSerializer.Deserialize<T2>(ref reader, options)!;
            _ = reader.Read();
			T3 item3 = JsonSerializer.Deserialize<T3>(ref reader, options)!;
            _ = reader.Read();
			T4 item4 = JsonSerializer.Deserialize<T4>(ref reader, options)!;
			_ = reader.Read();
            T5 item5 = JsonSerializer.Deserialize<T5>(ref reader, options)!;
            _ = reader.Read();
            T6 item6 = JsonSerializer.Deserialize<T6>(ref reader, options)!;
            _ = reader.Read();
            T7 item7 = JsonSerializer.Deserialize<T7>(ref reader, options)!;
            _ = reader.Read();
            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5, T6, T7> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            JsonSerializer.Serialize(writer, value.Item5, options);
            JsonSerializer.Serialize(writer, value.Item6, options);
            JsonSerializer.Serialize(writer, value.Item7, options);
            writer.WriteEndArray();
        }
    }
    internal sealed class TupleJsonConverter<T1, T2, T3, T4, T5, T6, T7, TRest> : JsonConverter<Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>> where TRest : notnull
    {
        public override Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			_ = reader.Read();
			T1 item1 = JsonSerializer.Deserialize<T1>(ref reader, options)!;
            _ = reader.Read();
			T2 item2 = JsonSerializer.Deserialize<T2>(ref reader, options)!;
            _ = reader.Read();
			T3 item3 = JsonSerializer.Deserialize<T3>(ref reader, options)!;
            _ = reader.Read();
			T4 item4 = JsonSerializer.Deserialize<T4>(ref reader, options)!;
			_ = reader.Read();
            T5 item5 = JsonSerializer.Deserialize<T5>(ref reader, options)!;
            _ = reader.Read();
            T6 item6 = JsonSerializer.Deserialize<T6>(ref reader, options)!;
            _ = reader.Read();
            T7 item7 = JsonSerializer.Deserialize<T7>(ref reader, options)!;
            _ = reader.Read();
            TRest rest = JsonSerializer.Deserialize<TRest>(ref reader, options)!;
            _ = reader.Read();
            return new Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>(item1, item2, item3, item4, item5, item6, item7, rest);
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            JsonSerializer.Serialize(writer, value.Item5, options);
            JsonSerializer.Serialize(writer, value.Item6, options);
            JsonSerializer.Serialize(writer, value.Item7, options);
            JsonSerializer.Serialize(writer, value.Rest, options);
            writer.WriteEndArray();
        }
    }
}
