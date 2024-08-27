using System;
using System.Diagnostics.CodeAnalysis;

namespace JsonSerialization.Nullability
{
	[SuppressMessage("Naming", "CA1716: Identifiers should not match keywords")]
	public readonly struct Optional<T> : IEquatable<Optional<T>>
	{
		public readonly T? Value { get; private init; } = default;
		public readonly bool HasValue { get; private init; } = false;
		public readonly bool IsNull { get; private init; } = false;
		public readonly bool IsUndefined { get; private init; } = true;
		public static readonly Optional<T> Undefined = new();

		public Optional() { }
		public Optional(T value)
		{
			Value = value;
			IsNull = value == null;
			HasValue = !IsNull;
			IsUndefined = false;
		}

		public override bool Equals(object? obj) => obj is Optional<T> other && Equals(other);
		public bool Equals(Optional<T> other)
		{
			return IsUndefined == other.IsUndefined
			&& IsNull == other.IsNull
			&& (IsNull || Value!.Equals(other.Value));
		}
		public override int GetHashCode(){
			return IsUndefined
			? 0
			: HashCode.Combine(IsUndefined, IsNull ? 0 : Value!.GetHashCode());
		}

		public static bool operator ==(Optional<T> left, Optional<T> right) => left.Equals(right);

		public static bool operator !=(Optional<T> left, Optional<T> right) => !(left == right);
	}
}