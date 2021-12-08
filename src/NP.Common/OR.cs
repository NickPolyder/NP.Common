namespace NP.Common
{
	/// <summary>
	/// A class providing two optional values.
	/// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	public class OR<T1, T2>
	{
		/// <summary>
		/// The left part of the <see cref="OR{T1, T2}"/>.
		/// </summary>
		public Maybe<T1> Left { get; }

		/// <summary>
		/// The right part of the <see cref="OR{T1, T2}"/>.
		/// </summary>
		public Maybe<T2> Right { get; }

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2}"/> with only the <seealso cref="Left" /> part.
		/// </summary>
		/// <param name="left"></param>
		public OR(T1 left)
		{
			Left = Maybe<T1>.WithValue(left);
			Right = Maybe<T2>.Empty;
		}

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2}"/> with only the <seealso cref="Right" /> part.
		/// </summary>
		/// <param name="right"></param>
		public OR(T2 right)
		{
			Left = Maybe<T1>.Empty;
			Right = Maybe<T2>.WithValue(right);
		}

		/// <summary>
		/// Extract the <see cref="Left"/> part of the <seealso cref="OR{T1, T2}"/>.
		/// </summary>
		/// <param name="or"></param>
		public static implicit operator T1(OR<T1, T2> or) => or.Left.Value;

		/// <summary>
		/// Extract the <see cref="Right"/> part of the <seealso cref="OR{T1, T2}"/>.
		/// </summary>
		/// <param name="or"></param>
		public static implicit operator T2(OR<T1, T2> or) => or.Right.Value;

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2}"/> with only the <seealso cref="Left" /> part.
		/// </summary>
		/// <param name="left"></param>
		public static implicit operator OR<T1, T2>(T1 left) => new OR<T1, T2>(left);

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2}"/> with only the <seealso cref="Right" /> part.
		/// </summary>
		/// <param name="right"></param>
		public static implicit operator OR<T1, T2>(T2 right) => new OR<T1, T2>(right);
	}
	/// <summary>
	/// A class providing three optional values.
	/// </summary>
	public class OR<T1, T2, T3>
	{
		/// <summary>
		/// The left part of the <see cref="OR{T1, T2, T3}"/>.
		/// </summary>
		public Maybe<T1> Left { get; }

		/// <summary>
		/// The middle part of the <see cref="OR{T1, T2, T3}"/>.
		/// </summary>
		public Maybe<T2> Middle { get; }

		/// <summary>
		/// The right part of the <see cref="OR{T1, T2, T3}"/>.
		/// </summary>
		public Maybe<T3> Right { get; }

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2, T3}"/> with only the <seealso cref="Left" /> part.
		/// </summary>
		/// <param name="left"></param>
		public OR(T1 left)
		{
			Left = Maybe<T1>.WithValue(left);
			Middle = Maybe<T2>.Empty;
			Right = Maybe<T3>.Empty;
		}

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2, T3}"/> with only the <seealso cref="Middle" /> part.
		/// </summary>
		/// <param name="middle"></param>
		public OR(T2 middle)
		{
			Left = Maybe<T1>.Empty;
			Middle = Maybe<T2>.WithValue(middle);
			Right = Maybe<T3>.Empty;
		}

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2, T3}"/> with only the <seealso cref="Right" /> part.
		/// </summary>
		/// <param name="right"></param>
		public OR(T3 right)
		{
			Left = Maybe<T1>.Empty;
			Middle = Maybe<T2>.Empty;
			Right = Maybe<T3>.WithValue(right);
		}

		/// <summary>
		/// Extract the <see cref="Left"/> part of the <seealso cref="OR{T1, T2, T3}"/>.
		/// </summary>
		/// <param name="or"></param>
		public static implicit operator T1(OR<T1, T2, T3> or) => or.Left.Value;

		/// <summary>
		/// Extract the <see cref="Middle"/> part of the <seealso cref="OR{T1, T2, T3}"/>.
		/// </summary>
		/// <param name="or"></param>
		public static implicit operator T2(OR<T1, T2, T3> or) => or.Middle.Value;

		/// <summary>
		/// Extract the <see cref="Right"/> part of the <seealso cref="OR{T1, T2, T3}"/>.
		/// </summary>
		/// <param name="or"></param>
		public static implicit operator T3(OR<T1, T2, T3> or) => or.Right.Value;

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2, T3}"/> with only the <seealso cref="Left" /> part.
		/// </summary>
		/// <param name="left"></param>
		public static implicit operator OR<T1, T2, T3>(T1 left) => new OR<T1, T2, T3>(left);

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2, T3}"/> with only the <seealso cref="Middle" /> part.
		/// </summary>
		/// <param name="middle"></param>
		public static implicit operator OR<T1, T2, T3>(T2 middle) => new OR<T1, T2, T3>(middle);

		/// <summary>
		/// Constructs an <see cref="OR{T1, T2, T3}"/> with only the <seealso cref="Right" /> part.
		/// </summary>
		/// <param name="right"></param>
		public static implicit operator OR<T1, T2, T3>(T3 right) => new OR<T1, T2, T3>(right);
	}
}