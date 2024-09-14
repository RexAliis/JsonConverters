using JsonSerialization.Converters;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace JsonSerialization.Nullability
{
	/// <summary>
	/// Represents an optional field that can be undefined or present.
	/// </summary>
	[SuppressMessage("Naming", "CA1716: Identifiers should not match keywords")]
	[JsonConverter(typeof(OptionalFieldJsonConverter))]
	public readonly struct Optional : IEquatable<Optional>
	{
		/// <summary>
		/// Gets a value indicating whether the current <see cref="Optional"/> instance is in its undefined state.
		/// </summary>
		public readonly bool IsUndefined => !_isInitialized;
		private readonly bool _isInitialized;

		/// <summary>
		/// Represents a undefined state for <see cref="Optional"/>.
		/// </summary>
		public static readonly Optional Undefined;

		/// <summary>
		/// Initializes a new instance of the <see cref="Optional"/> in an defined state.
		/// </summary>
		public Optional() => _isInitialized = true;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is Optional other && Equals(other);

		/// <inheritdoc/>
		public bool Equals(Optional other) => IsUndefined == other.IsUndefined;

		/// <inheritdoc/>
		public override int GetHashCode() => IsUndefined.GetHashCode();

		/// <inheritdoc/>
		public static bool operator ==(Optional left, Optional right) => left.Equals(right);

		/// <inheritdoc/>
		public static bool operator !=(Optional left, Optional right) => !(left == right);
	}
	/// <summary>
	/// Encapsulates an optional value that can be undefined, null, or assigned a valid value.
	/// </summary>
	/// <typeparam name="T">The underlying type of the optional value.</typeparam>
	[SuppressMessage("Naming", "CA1716: Identifiers should not match keywords")]
	[JsonConverter(typeof(OptionalConverter))]
	public readonly struct Optional<T> : IEquatable<Optional<T>>
	{
		/// <summary>
		/// Gets the underlying value of the current <see cref="Optional{T}"/> instance.
		/// The value may be <c>null</c> if <typeparamref name="T"/> is a reference or nullable type.
		/// </summary>
		public readonly T? Value { get; private init; } = default;

		/// <summary>
		/// Gets a value indicating whether the current <see cref="Optional{T}"/> instance contains a non-null value.
		/// If <typeparamref name="T"/> is a non-nullable type, this property will be <c>true</c> as long as the instance is not in its undefined state.
		/// </summary>
		public readonly bool HasValue => Value != null && _isInitialized;

		/// <summary>
		/// Gets a value indicating whether the current <see cref="Optional{T}"/> instance contains a null value.
		/// This property is always <c>false</c> if <typeparamref name="T"/> is a non-nullable value type.
		/// </summary>
		public readonly bool IsNull => Value == null && _isInitialized;

		/// <summary>
		/// Gets a value indicating whether the current <see cref="Optional{T}"/> instance is in its undefined state.
		/// </summary>
		public readonly bool IsUndefined => !_isInitialized;
		private readonly bool _isInitialized;

		/// <summary>
		/// Represents a undefined state for <see cref="Optional{T}"/>.
		/// </summary>
		public static readonly Optional<T> Undefined;

		/// <summary>
		/// Initializes a new instance of the <see cref="Optional{T}"/> in an undefined state.
		/// </summary>
		public Optional() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Optional{T}"/> struct with the specified value.
		/// If the provided value is null, the instance will be marked as null. 
		/// </summary>
		/// <param name="value">The value to be assigned to this instance.</param>
		public Optional(T value)
		{
			Value = value;
			_isInitialized = true;
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is Optional<T> other && Equals(other);

		/// <inheritdoc/>
		public bool Equals(Optional<T> other)
		{
			return (IsUndefined == other.IsUndefined)
			&& (IsUndefined
			|| (IsNull == other.IsNull
			&& (IsNull || Value!.Equals(other.Value))));
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
