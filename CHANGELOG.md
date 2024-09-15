# Changelog

## v3.2.0

### Added

- Implicit conversion from `T` to `JsonSerialization.Nullability.Optional<T>`
- Implicit conversion `JsonSerialization.Nullability.Optional<T>` to `T`
- Implicit conversion from `bool` to `JsonSerialization.Nullability.Optional`
- Implicit conversion from `JsonSerialization.Nullability.Optional` to `bool`

## v3.1.0

### Changed

- Access to `JsonSerialization.Converters.OptionalConverter` is now `public`
- Access to `JsonSerialization.Converters.OptionalFieldJsonConverter` is now `public`

## v3.0.1

### Fixed

- `JsonSerialization.Nullability.Optional<T>` Comparisons against the default value no longer cause a NullReferenceException

## v3.0.0

### Added

- Missing `JsonSerialization.Converters.OptionalFieldConverter` converter for `JsonSerialization.Nullability.Optional`
- Now `JsonSerialization.Converters.OptionalFieldConverter` and `JsonSerialization.Converters.OptionalConverter` have the `System.Text.Json.Serialization.JsonConverterAttribute`

### Changed

- Access to `JsonSerialization.Converters.OptionalConverter` is now `internal`

## v2.1.0

### Added

- `JsonSerialization.Nullability.Optional`

## v2.0.0

### Added

- Xml comments documentation for the entire API

### Removed

- `JsonSerialization.Converters.ExtendedJsonConverter`
- `JsonSerialization.Converters.ImmutableArrayConverter`
- `JsonSerialization.Converters.ImmutableDictionaryConverter`

## v1.1.0

### Added

- `JsonSerialization.Nullability.Optional<T>`.HasValue property
- `JsonSerialization.Nullability.Optional<T>` T now accepts nullable types

## v1.0.0

### Added

- `JsonSerialization.Nullability.Optional<T>`
- `JsonSerialization.Converters.OptionalConverter` converter
- `System.Tuple` and `System.ValueTuple` `JsonSerialization.Converters.TupleConverter` converter
- `JsonSerialization.Converters.ImmutableArrayConverter` converter
- `JsonSerialization.Converters.ImmutableDictionaryConverter` converter
