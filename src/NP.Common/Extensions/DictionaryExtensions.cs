using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NP.Common.Extensions
{
	/// <summary>
	/// Extensions for <see cref="IDictionary{TKey, TValue}"/>.
	/// </summary>
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Gets a value or generates one with <paramref name="factory"/> and then returns the value..
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="dictionary">This dictionary.</param>
		/// <param name="key">The key to fetch.</param>
		/// <param name="factory">Value factory.</param>
		/// <returns>The <typeparamref name="TValue"/> related to the <paramref name="key"/>.</returns>
		/// <exception cref="ArgumentNullException">
		/// When the <paramref name="dictionary"/> or <paramref name="factory"/>
		/// are null.
		/// </exception>
		public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,
			Func<TKey, TValue> factory)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException(nameof(dictionary));
			}

			if (factory == null)
			{
				throw new ArgumentNullException(nameof(factory));
			}

			if (dictionary.TryGetValue(key, out var result))
			{
				return result;
			}

			var generatedValue = factory(key);
			dictionary.Add(key, generatedValue);

			return generatedValue;
		}
	}
}
