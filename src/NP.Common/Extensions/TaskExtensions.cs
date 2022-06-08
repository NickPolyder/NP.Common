using System.Threading.Tasks;
using System.Threading;
using System;
using System.Globalization;

namespace NP.Common.Extensions
{
	/// <summary>
	/// Extensions related to Tasks.
	/// </summary>
	public static class TaskExtensions
	{
		/// <summary>
		/// From https://github.com/aspnet/AspNetIdentity/blob/main/src/Microsoft.AspNet.Identity.Core/AsyncHelper.cs
		/// </summary>

		private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None,
			TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

		/// <summary>
		///  Wrap to a Task result.
		/// </summary>
		/// <param name="obj">The object to be wrapped.</param>
		/// <returns></returns>
		public static Task<TResult> AsTask<TResult>(this TResult obj)
		{
			return Task.FromResult(obj);
		}

		/// <summary>
		///  Wrap to a Task exception.
		/// </summary>
		/// <param name="obj">The object to be wrapped.</param>
		/// <returns></returns>
		public static Task AsTask(this Exception obj)
		{
			return Task.FromException(obj);
		}

		/// <summary>
		///  Wrap to a Task exception.
		/// </summary>
		/// <param name="obj">The object to be wrapped.</param>
		/// <returns></returns>
		public static Task<TResult> AsTask<TResult>(this Exception obj)
		{
			return Task.FromException<TResult>(obj);
		}

		/// <summary>
		/// Runs a Task synchronously.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="task"></param>
		/// <returns></returns>
		public static TResult RunSync<TResult>(this Task<TResult> task)
		{
			return RunSync(() => task);
		}

		/// <summary>
		/// Runs a Task synchronously.
		/// </summary>
		/// <param name="task"></param>
		public static void RunSync(this Task task)
		{
			RunSync(() => task);
		}

		/// <summary>
		/// Runs a Task synchronously.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="func"></param>
		/// <returns></returns>
		public static TResult RunSync<TResult>(Func<Task<TResult>> func)
		{
			var cultureUi = CultureInfo.CurrentUICulture;
			var culture = CultureInfo.CurrentCulture;
			return _myTaskFactory.StartNew(() =>
			{
				Thread.CurrentThread.CurrentCulture = culture;
				Thread.CurrentThread.CurrentUICulture = cultureUi;
				return func();
			}).Unwrap().GetAwaiter().GetResult();
		}

		/// <summary>
		/// Runs a Task synchronously. 
		/// </summary>
		/// <param name="func"></param>
		public static void RunSync(Func<Task> func)
		{
			var cultureUi = CultureInfo.CurrentUICulture;
			var culture = CultureInfo.CurrentCulture;
			_myTaskFactory.StartNew(() =>
			{
				Thread.CurrentThread.CurrentCulture = culture;
				Thread.CurrentThread.CurrentUICulture = cultureUi;
				return func();
			}).Unwrap().GetAwaiter().GetResult();
		}
	}
}