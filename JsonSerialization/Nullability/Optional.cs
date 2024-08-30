using System;
using System.Diagnostics.CodeAnalysis;

namespace JsonSerialization.Nullability
{
	/// <summary>
	/// Encapsulates an optional value that can be in one of three states: undefined, null, or assigned a valid value.
	/// This struct provides a robust way to represent optional data, with explicit handling of null and undefined states.
	/// </summary>
	/// <typeparam name="T">The underlying type of the optional value.</typeparam>
	[SuppressMessage("Naming", "CA1716: Identifiers should not match keywords")]
	public readonly struct Optional<T> : IEquatable<Optional<T>>
	{
		/// <summary>
		/// Gets the underlying value of the current <see cref="Optional{T}"/> instance.
		/// The value may be <c>null</c> if <typeparamref name="T"/> is a reference or nullable type.
		/// </summary>
		public readonly T? Value { get; private init; }

		/// <summary>
		/// Gets a value indicating whether the current <see cref="Optional{T}"/> instance contains a non-null value.
		/// If <typeparamref name="T"/> is a non-nullable type, this property will be <c>true</c> as long as the instance is not in its undefined state.
		/// </summary>
		public readonly bool HasValue => !IsNull;

		/// <summary>
		/// Gets a value indicating whether the current <see cref="Optional{T}"/> instance contains a null value.
		/// This property is always <c>false</c> if <typeparamref name="T"/> is a non-nullable value type.
		/// </summary>
		public readonly bool IsNull => Value == null;

		/// <summary>
		/// Gets a value indicating whether the current <see cref="Optional{T}"/> instance is in its undefined state.
		/// </summary>
		public readonly bool IsUndefined => this == default;

		/// <summary>
		/// Represents a undefined state for <see cref="Optional{T}"/>.
		/// </summary>
		public static readonly Optional<T> Undefined;

		/// <summary>
		/// Initializes a new instance of the <see cref="Optional{T}"/> in an undefined state.
		/// </summary>
		public Optional() => Value = default;

		/// <summary>
		/// Initializes a new instance of the <see cref="Optional{T}"/> struct with the specified value.
		/// If the provided value is null, the instance will be marked as null. 
		/// </summary>
		/// <param name="value">The value to be assigned to this instance.</param>
		public Optional(T value) => Value = value;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is Optional<T> other && Equals(other);

		/// <inheritdoc/>
		public bool Equals(Optional<T> other)
		{
			return IsNull == other.IsNull
			&& (IsNull || Value!.Equals(other.Value));
		}

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			return IsUndefined
			? 0
			: HashCode.Combine(IsUndefined, IsNull ? 0 : Value!.GetHashCode());
		}

		/// <inheritdoc/>
		public static bool operator ==(Optional<T> left, Optional<T> right) => left.Equals(right);

		/// <inheritdoc/>
		public static bool operator !=(Optional<T> left, Optional<T> right) => !(left == right);
	}
}