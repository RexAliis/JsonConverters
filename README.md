# [Json Serialization](https://www.nuget.org/packages/RexAliis.JsonSerialization/)

A library for serializing/deserializing types

Provides functionality for distinguishing between `null` types and the `undefined` state.

## Supported types

- System.Tuple
- System.ValueTuple
- JsonSerialization.Nullability.Optional

```cs
using JsonSerialization.Converters;

JsonSerializerOptions options = new()
{
    Converters = 
    {
        new TupleConverter()
    }
};

JsonSerializer.Serialize((1, 2, 3, 4), options); // string [1,2,3,4]
JsonSerializer.Deserialize<(int, int, int, int)>("[5,6,7,8]", options); // ValueTuple<int, int, int, int> (5, 6, 7, 8)
```

## Nullability

### Remarks

For the Value to be able to be null, the generic parameter T must be nullable.

### Example

Example class:

```cs
using JsonSerialization.Nullability;

class User
{
    public required ulong ID { get; init; }
    public required string Username { get; init; }
    public Optional<string> GlobalName { get; init; }
    public Optional<string?> GroupNickname { get; init; }
    public Optional HasPremium { get; init; }
}
```

Optional converter:

```cs
using JsonSerialization.Converters;
using System.Text.Json;

JsonSerializerOptions options = new()
{
    Converters = 
    {
        new OptionalConverter()
    }
};
```
