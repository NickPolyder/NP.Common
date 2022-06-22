using System.Collections.Generic;
using System;

namespace NP.Common.Extensions
{
	/// <summary>
	/// 
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Cast <paramref name="obj"/> to <typeparamref name="TTo"/>.
		/// </summary>
		/// <typeparam name="TTo"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static TTo As<TTo>(this object obj)
		{
			if (obj is TTo y)
			{
				return y;
			}

			return default(TTo);
		}

		/// <summary>
		/// Checks if the object is null.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsNull(this object obj) => obj == null;

		/// <summary>
		/// Clones the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <returns>The cloned object.</returns>
		public static T Clone<T>(this T source) where T : ICloneable
		{
			if (source == null)
			{
				return default(T);
			}

			return (T)source.Clone();
		}

		/// <summary>
		/// Clones each item of <paramref name="sources"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sources"></param>
		/// <returns>The collection of cloned objects.</returns>
		public static IEnumerable<T> Clone<T>(this IEnumerable<T> sources) where T : ICloneable
		{
			if (sources == null)
			{
				yield break;
			}

			foreach (var source in sources)
			{
				yield return source.Clone<T>();
			}
		}

		/// <summary>
		/// Format <paramref name="stringToFormat"/> with <paramref name="args"/>.
		/// </summary>
		/// <param name="stringToFormat">The string to be formatted.</param>
		/// <param name="args">The arguments that will be used to format the string.</param>
		/// <returns>The formatted string.</returns>
		public static string With(this string stringToFormat, params object[] args)
		{
			return string.Format(stringToFormat, args);
		}

	}
}