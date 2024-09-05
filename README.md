# [Json Serialization](https://www.nuget.org/packages/RexAliis.JsonSerialization/)

A library for serializing/deserializing types

Provides functionality for distinguishing between `null` types and the `undefined` state.

## Supported types

- `System.Tuple`
- `System.ValueTuple`
- `JsonSerialization.Nullability.Optional`
- `JsonSerialization.Nullability.Optional<T>`

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

There is no need to declare converters for `Optional` and `Optional<T>` in the serialization options, as they are implemented through the `JsonConverterAttribute`.
For correct serialization, it is necessary that the ignore condition be `JsonIgnoreCondition.WhenWritingDefault`.

Example class:

```cs
using JsonSerialization.Nullability;

class User
{
    public required int ID { get; init; }
    public required string Username { get; init; }
    public Optional<string> GlobalName { get; init; }
    public Optional<string?> GroupNickname { get; init; }
    public Optional HasPremium { get; init; }
}
```

Example uses:

```cs
using System.Text.Json;

User exampleUser;
```

```cs
exampleUser = new()
{
    ID = 1,
    Username = "qwerty",
    GlobalName = new("Qwerty"),
    GroupNickname = new(null),
    HasPremium = new()
}

JsonSerializer.Serialize(exampleUser);
/*
 * {
 *     ID: 1,
 *     Username: "qwerty",
 *     GlobalName: "Qwerty",
 *     GroupNickname: null,
 *     HasPremium: null
 * }
*/
```

```cs
exampleUser = new()
{
    ID = 12345678901234567,
    Username = "qwerty",
    GlobalName = new(), // Is Undefined
    GroupNickname = new() // Is Undefined
    HasPremium = new() // Is present
}

JsonSerializer.Serialize(exampleUser);
/*
 * {
 *     ID: 1,
 *     Username: "qwerty",
 *     HasPremium: null
 * }
*/
```

```cs
exampleUser = new()
{
    ID = 12345678901234567,
    Username = "qwerty",
    // GlobalName is Undefined
    // GroupNickname is Undefined
    // HasPremium is not present
}

JsonSerializer.Serialize(exampleUser);
/*
 * {
 *     ID: 1,
 *     Username: "qwerty",
 * }
*/

```
