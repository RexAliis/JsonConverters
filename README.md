# Json Serialization
A library for serializing/deserializing widely known types in the .NET API

Provides functionality for distinguishing between `null` types and the `undefined` state.
### Install
```
dotnet add package RexAliis.JsonSerialization --version 1.0.0
```

### Supported natitypes
 - Tuple
 - ValueTuple
 - ImmutableArray
 - ImmutableDictionary

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

### Nullability

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
Console.WriteLine(firstUser.Nickname.Value); //null
Console.WriteLine(firstUser.Nickname.IsNull); //false
Console.WriteLine(firstUser.Nickname.IsUndefined); //true

User secondUser = JsonSerializer.Deserialize<User>("""
{
    "Username": "asdfgh",
    "Nickname": null
}
""", options)!;
Console.WriteLine(secondUser.Nickname.Value); //null
Console.WriteLine(secondUser.Nickname.IsNull); //true
Console.WriteLine(secondUser.Nickname.IsUndefined); //false

User thirdUser = JsonSerializer.Deserialize<User>("""
{
    "Username": "zxcvbn",
    "Nickname": "zxcvbn dude"
}
""", options)!;
Console.WriteLine(thirdUser.Nickname.Value); //"zxcvbn dude"
Console.WriteLine(thirdUser.Nickname.IsNull); //false
Console.WriteLine(thirdUser.Nickname.IsUndefined); //false
```
