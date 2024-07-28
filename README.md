# Tuple Json Conveters
A library that allows you to deserealize/serealize C# Tuple and ValueTuple

```cs
using TupleJsonConverters;

JsonSerializerOptions options = new()
{
    Converters = { new TupleConverter() }
};

JsonSerializer.Serialize((1, 2, 3, 4), options); // [1,2,3,4]
JsonSerializer.Deserialize<(int, int, int, int)>("[5,6,7,8]", options); //ValueTuple<int, int, int, int>(5, 6, 7, 8);
```
