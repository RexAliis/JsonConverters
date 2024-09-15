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
using System.Text.Json.Serialization;
using static System.Text.Json.Serialization.JsonIgnoreCondition;

class User
{
    public required int ID { get; init; }
    public required string Username { get; init; }
    [JsonIgnore(Condition = WhenWritingDefault)]
    public Optional<string> GlobalName { get; init; }
    [JsonIgnore(Condition = WhenWritingDefault)]
    public Optional<string?> GroupNickname { get; init; }
    [JsonIgnore(Condition = WhenWritingDefault)]
    public Optional HasPremium { get; init; }
}
```

Example uses:

```cs
using System.Text.Json;

User firstUser = new()
{
    ID = 1,
    Username = "qwerty",
    GlobalName = "Qwerty",
    GroupNickname = null,
    HasPremium = true
}

string firstUserSerialized = JsonSerializer.Serialize(firstUser);
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
using System.Text.Json;

User secondUser = new()
{
    ID = 12345678901234567,
    Username = "qwerty",
}

string secondUserSerialized = JsonSerializer.Serialize(secondUser);
/*
 * {
 *     ID: 1,
 *     Username: "qwerty",
 * }
*/

```cs
using System.Text.Json;
using JsonSerialization.Nullability;

string jsonUser = "{ID: 1,Username: \"qwerty\",GlobalName: \"Qwerty\",GroupNickname: null,HasPremium: null}";
User myUser = JsonSerializer.Deserialize<User>(jsonUser)!;

Console.WriteLine($"Hello {(myUser.GlobalName.HasValue ? myUser.GlobalName : myUser.Username)}");
if (myUser.HasPremium)
{
    Console.WriteLine("Premium features ON");
}
```
