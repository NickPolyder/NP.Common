using System;
using System.Collections.Generic;

namespace NP.Common.Extensions
{
	/// <summary>
	/// Collection Extensions
	/// </summary>
	public static class CollectionExtensions
	{
		/// <summary>
		/// Add to the <paramref name="collection"/> if the <paramref name="predicate"/> is met.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="collection"></param>
		/// <param name="predicate"></param>
		/// <param name="value"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static void AddIf<T>(this ICollection<T> collection, Predicate<T> predicate, T value)
		{
			if (collection == null)
			{
				throw new ArgumentNullException(nameof(collection));
			}

			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}
			
			if (predicate(value))
			{
				collection.Add(value);
			}
		}
	}
}