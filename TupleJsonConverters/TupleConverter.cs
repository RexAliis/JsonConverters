using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TupleJsonConverters
{
    public sealed class TupleConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert == null || !typeToConvert.IsGenericType) return false;

            Type typeDefinition = typeToConvert.GetGenericTypeDefinition();

            return typeToConvert.IsClass
                ? typeDefinition == typeof(Tuple<>)
                    || typeDefinition == typeof(Tuple<,>)
                    || typeDefinition == typeof(Tuple<,,>)
                    || typeDefinition == typeof(Tuple<,,,>)
                    || typeDefinition == typeof(Tuple<,,,,>)
                    || typeDefinition == typeof(Tuple<,,,,,>)
                    || typeDefinition == typeof(Tuple<,,,,,,>)
                    || typeDefinition == typeof(Tuple<,,,,,,,>)
                : typeDefinition == typeof(ValueTuple<>)
                    || typeDefinition == typeof(ValueTuple<,>)
                    || typeDefinition == typeof(ValueTuple<,,>)
                    || typeDefinition == typeof(ValueTuple<,,,>)
                    || typeDefinition == typeof(ValueTuple<,,,,>)
                    || typeDefinition == typeof(ValueTuple<,,,,,>)
                    || typeDefinition == typeof(ValueTuple<,,,,,,>)
                    || typeDefinition == typeof(ValueTuple<,,,,,,,>);
        }
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert == null) throw new ArgumentNullException(nameof(typeToConvert));
            Type converter = GetConverterType(typeToConvert);
            return (Activator.CreateInstance(converter) as JsonConverter)!;
        }
        private static Type GetConverterType(Type type)
        {
            Type[] arguments = type.GetGenericArguments();

            return type.IsClass
                ? arguments.Length switch
                {
                    1 => typeof(TupleJsonConverter<>).MakeGenericType(arguments),
                    2 => typeof(TupleJsonConverter<,>).MakeGenericType(arguments),
                    3 => typeof(TupleJsonConverter<,,>).MakeGenericType(arguments),
                    4 => typeof(TupleJsonConverter<,,,>).MakeGenericType(arguments),
                    5 => typeof(TupleJsonConverter<,,,,>).MakeGenericType(arguments),
                    6 => typeof(TupleJsonConverter<,,,,,>).MakeGenericType(arguments),
                    7 => typeof(TupleJsonConverter<,,,,,,>).MakeGenericType(arguments),
                    8 => typeof(TupleJsonConverter<,,,,,,,>).MakeGenericType(arguments),
                    _ => throw new InvalidOperationException()
                }
                : arguments.Length switch
                {
                    1 => typeof(ValueTupleJsonConverter<>).MakeGenericType(arguments),
                    2 => typeof(ValueTupleJsonConverter<,>).MakeGenericType(arguments),
                    3 => typeof(ValueTupleJsonConverter<,,>).MakeGenericType(arguments),
                    4 => typeof(ValueTupleJsonConverter<,,,>).MakeGenericType(arguments),
                    5 => typeof(ValueTupleJsonConverter<,,,,>).MakeGenericType(arguments),
                    6 => typeof(ValueTupleJsonConverter<,,,,,>).MakeGenericType(arguments),
                    7 => typeof(ValueTupleJsonConverter<,,,,,,>).MakeGenericType(arguments),
                    8 => typeof(ValueTupleJsonConverter<,,,,,,,>).MakeGenericType(arguments),
                    _ => throw new InvalidOperationException()
                };
        }
    }
}
