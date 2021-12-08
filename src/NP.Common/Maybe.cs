using System;
using System.Collections.Generic;

namespace NP.Common
{
	/// <summary>
	///  <see cref="Maybe{T}"/> works as <see cref="Nullable{T}"/> but for both classes and structs.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Maybe<T> : IEquatable<Maybe<T>>
	{
		/// <summary>
		/// Has a value ?
		/// </summary>
		public bool HasValue { get; }

		/// <summary>
		/// The actual value.
		/// </summary>
		public T Value { get; }

		private Maybe()
		{
			HasValue = false;
			Value = default;
		}

		private Maybe(T value)
		{
			HasValue = true;
			Value = value;
		}

		/// <summary>
		/// Creates a <see cref="Maybe{T}"/> with the <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The <see cref="Maybe{T}"/> with the <paramref name="value"/>.</returns>
		public static Maybe<T> WithValue(T value)
		{
			return new Maybe<T>(value);
		}

		/// <summary>
		/// An Empty <see cref="Maybe{T}"/> value.
		/// </summary>
		public static Maybe<T> Empty { get; } = new Maybe<T>();

		/// <inheritdoc />
		public bool Equals(Maybe<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			var isTrue = HasValue == other.HasValue;
			if(Value is IEquatable<T> equatable)
			{
				isTrue = isTrue && equatable.Equals(other.Value);
			}
			else
			{
				isTrue = isTrue && EqualityComparer<T>.Default.Equals(Value, other.Value);
			}

			return isTrue;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != GetType())
			{
				return false;
			}

			return Equals((Maybe<T>)obj);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				return HasValue.GetHashCode() * 397 ^ EqualityComparer<T>.Default.GetHashCode(Value);
			}
		}

		/// <inheritdoc />
		public static bool operator ==(Maybe<T> left, Maybe<T> right)
		{
			return Equals(left, right);
		}

		/// <inheritdoc />
		public static bool operator !=(Maybe<T> left, Maybe<T> right)
		{
			return !Equals(left, right);
		}
	}
}