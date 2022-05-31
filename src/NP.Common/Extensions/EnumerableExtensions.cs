using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NP.Common.Extensions
{
	/// <summary>
	/// Enumerable Extensions
	/// </summary>
	public static class EnumerableExtensions
	{

		#region IEnumerable

		/// <summary>
		/// Loops through <paramref name="enumerable"/> and invokes <paramref name="execute"/>.
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="execute"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static void ForEach(this IEnumerable enumerable, Action<object> execute)
		{
			if (enumerable == null)
			{
				return;
			}

			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			foreach (var obj in enumerable)
			{
				execute.Invoke(obj);	
			}
		}

		/// <summary>
		/// Loops through <paramref name="enumerable"/> and invokes <paramref name="execute"/>.
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="execute"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static void ForEach(this IEnumerable enumerable, Action<object, int> execute)
		{
			if (enumerable == null)
			{
				return;
			}

			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			var index = 0;
			foreach (var obj in enumerable)
			{
				execute.Invoke(obj, index++);
			}
		}

		/// <summary>
		/// Loops through <paramref name="enumerable"/> and invokes <paramref name="execute"/>.
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="execute"></param>
		/// <param name="cancellationToken"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static async Task ForEachAsync(this IEnumerable enumerable,
			Func<object, CancellationToken, Task> execute,
			CancellationToken cancellationToken = default)
		{
			if (enumerable == null)
			{
				return;
			}

			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			foreach (var obj in enumerable)
			{
				await execute.Invoke(obj, cancellationToken);
			}
		}

		/// <summary>
		/// Loops through <paramref name="enumerable"/> and invokes <paramref name="execute"/>.
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="execute"></param>
		/// <param name="cancellationToken"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static async Task ForEachAsync(this IEnumerable enumerable,
			Func<object, int, CancellationToken, Task> execute,
			CancellationToken cancellationToken = default)
		{
			if (enumerable == null)
			{
				return;
			}

			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			var index = 0;
			foreach (var obj in enumerable)
			{
				await execute.Invoke(obj, index++, cancellationToken);
			}
		}

		#endregion
		
		#region IEnumerable<T>

		/// <summary>
		/// Loops through <paramref name="enumerable"/> and invokes <paramref name="execute"/>.
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="execute"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> execute)
		{
			if (enumerable == null)
			{
				return;
			}

			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			foreach (var obj in enumerable)
			{
				execute.Invoke(obj);
			}
		}

		/// <summary>
		/// Loops through <paramref name="enumerable"/> and invokes <paramref name="execute"/>.
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="execute"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> execute)
		{
			if (enumerable == null)
			{
				return;
			}

			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			var index = 0;
			foreach (var obj in enumerable)
			{
				execute.Invoke(obj, index++);
			}
		}

		/// <summary>
		/// Loops through <paramref name="enumerable"/> and invokes <paramref name="execute"/>.
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="execute"></param>
		/// <param name="cancellationToken"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable,
			Func<T, CancellationToken, Task> execute,
			CancellationToken cancellationToken = default)
		{
			if (enumerable == null)
			{
				return;
			}

			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			foreach (var obj in enumerable)
			{
				await execute.Invoke(obj, cancellationToken);
			}
		}

		/// <summary>
		/// Loops through <paramref name="enumerable"/> and invokes <paramref name="execute"/>.
		/// </summary>
		/// <param name="enumerable"></param>
		/// <param name="execute"></param>
		/// <param name="cancellationToken"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable,
			Func<T, int, CancellationToken, Task> execute,
			CancellationToken cancellationToken = default)
		{
			if (enumerable == null)
			{
				return;
			}

			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			var index = 0;
			foreach (var obj in enumerable)
			{
				await execute.Invoke(obj, index++, cancellationToken);
			}
		}

		#endregion

	}
}