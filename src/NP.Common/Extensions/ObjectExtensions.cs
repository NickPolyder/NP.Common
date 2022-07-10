using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

		/// <summary>
		/// Executes the <paramref name="functor"/> if the <paramref name="obj"/> is of <typeparamref name="TObject"/>.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="obj"></param>
		/// <param name="functor"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static TResult If<TObject, TResult>(this object obj, Func<TObject, TResult> functor)
		{
			if (obj == null)
			{
				return default(TResult);
			}

			if (functor == null)
			{
				throw new ArgumentNullException(nameof(functor));
			}

			if (obj is TObject value)
			{
				return functor(value);
			}

			return default(TResult);
		}

		/// <summary>
		/// Executes the <paramref name="functor"/> if the <paramref name="obj"/> is of <typeparamref name="TObject"/>.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="obj"></param>
		/// <param name="functor"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static async Task<TResult> IfAsync<TObject, TResult>(this object obj, Func<TObject, CancellationToken, Task<TResult>> functor, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (obj == null)
			{
				return default(TResult);
			}

			if (functor == null)
			{
				throw new ArgumentNullException(nameof(functor));
			}

			if (obj is TObject value)
			{
				return await functor(value, cancellationToken);
			}

			return default(TResult);
		}

		/// <summary>
		/// Executes the <paramref name="action"/> if the <paramref name="obj"/> is of <typeparamref name="TObject"/>.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="obj"></param>
		/// <param name="action"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static void If<TObject>(this object obj, Action<TObject> action)
		{
			if (obj == null)
			{
				return;
			}

			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			if (obj is TObject value)
			{
				action(value);
			}
		}

		/// <summary>
		/// Executes the <paramref name="action"/> if the <paramref name="obj"/> is of <typeparamref name="TObject"/>.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="obj"></param>
		/// <param name="action"></param>
		/// <param name="cancellationToken"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static async Task IfAsync<TObject>(this object obj, Func<TObject, CancellationToken, Task> action, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (obj == null)
			{
				return;
			}

			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			if (obj is TObject value)
			{
				await action(value, cancellationToken);
			}
		}

		/// <summary>
		/// Converts <paramref name="value"/> to a byte array.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static byte[] ToByteArray(this string value, Encoding encoding = null)
		{
			var currentEncoding = encoding ?? Encoding.UTF8;

			return !string.IsNullOrWhiteSpace(value)
				? currentEncoding.GetBytes(value)
				: Array.Empty<byte>();
		}

		/// <summary>
		/// Converts <paramref name="value"/> to a byte array.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static byte[] ToByteArray(this Stream value)
		{
			if (value == null)
			{
				return Array.Empty<byte>();
			}

			using (var ms = new MemoryStream())

			{
				value.CopyTo(ms);
				return ms.ToArray();
			}
		}

		/// <summary>
		/// Converts <paramref name="value"/> to a Stream.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static Stream ToStream(this string value, Encoding encoding = null)
		{
			return value.ToByteArray(encoding).ToStream();
		}

		/// <summary>
		/// Converts <paramref name="value"/> to a Stream.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Stream ToStream(this byte[] value)
		{
			return new MemoryStream(value);
		}

	}
}