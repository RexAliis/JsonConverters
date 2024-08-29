# Json Serialization

A library for serializing/deserializing types

Provides functionality for distinguishing between `null` types and the `undefined` state.

## Install

```bash
dotnet add package RexAliis.JsonSerialization --version 2.0.0
```

## Supported types

- System.Tuple
- System.ValueTuple
- JsonSerialization.Optional

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

Example class:

```cs
using JsonSerialization.Nullability;

internal sealed class User
{
    public required string Username { get; init; }
    public Optional<string> Nickname { get; init; }
}
```

Main file:

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

User firstUser = JsonSerializer.Deserialize<User>("""
{
    "Username": "qwerty"
}
""", options)!;
/*
 * Username = "qwerty"
 * Nickname
 * {
 *     Value = null
 *     HasValue = false,
 *     IsNull = false,
 *     IsUndefined = true
 * }
*/

User secondUser = JsonSerializer.Deserialize<User>("""
{
    "Username": "asdfgh",
    "Nickname": null
}
""", options)!;
/*
 * Username = "asdfgh"
 * Nickname
 * {
 *     Value = null
 *     HasValue = false,
 *     IsNull = true,
 *     IsUndefined = false
 * }
*/

User thirdUser = JsonSerializer.Deserialize<User>("""
{
    "Username": "zxcvbn",
    "Nickname": "zxcvbn dude"
}
""", options)!;
/*
 * Username = "zxcvbn"
 * Nickname
 * {
 *     Value = "zxcvbn dude"
 *     HasValue = true,
 *     IsNull = false,
 *     IsUndefined = false
 * }
*/
```
