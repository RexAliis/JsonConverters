# Json Conveters
A library to serialize/deserialize types without native .NET json converters

### Install
```
dotnet add package RexAliis.JsonConverters --version 1.0.0
```

### Supported types
 - Tuple
 - ValueTuple
 - ImmutableArray
 - ImmutableDictionary

```cs
using JsonConverters;

JsonSerializerOptions options = new()
{
    Converters = 
    {
        new TupleConverter(),
        new ImmutableArrayConverter(),
    }
};

JsonSerializer.Serialize((1, 2, 3, 4), options); // string [1,2,3,4]
JsonSerializer.Deserialize<(int, int, int, int)>("[5,6,7,8]", options); // ValueTuple<int, int, int, int> (5, 6, 7, 8)

JsonSerializer.Serialize(ImmutableArray.Create("a", "b")); // string ["a","b"]
JsonSerializer.Deserialize<ImmutableArray<string>>("""["c","d"]"""); // ImmutableArray<string> ["c", "d"]
```
