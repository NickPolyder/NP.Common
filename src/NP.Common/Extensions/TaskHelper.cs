using System;
using System.Threading;
using System.Threading.Tasks;

namespace NP.Common.Extensions
{
	/// <summary>
	/// A helper that allows a delegate to be transformed to a Task
	/// </summary>
	public class TaskHelper
	{
		/// <summary>
		/// Turn a processor to a dummy task.
		/// </summary>
		/// <param name="processor"></param>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <typeparam name="TRequest"></typeparam>
		/// <typeparam name="TResponse"></typeparam>
		/// <returns></returns>
		public static Task<TResponse> ConvertToTask<TRequest, TResponse>(Func<TRequest, TResponse> processor,
			TRequest request,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			try
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled<TResponse>(cancellationToken);
				}

				return Task.FromResult(processor(request));
			}
			catch (System.Exception ex)
			{
				return Task.FromException<TResponse>(ex);
			}
		}

		/// <summary>
		/// Turn a processor to a dummy task.
		/// </summary>
		/// <param name="processor"></param>
		/// <param name="cancellationToken"></param>
		/// <typeparam name="TResponse"></typeparam>
		/// <returns></returns>
		public static Task<TResponse> ConvertToTask<TResponse>(Func<TResponse> processor,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			try
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled<TResponse>(cancellationToken);
				}

				return Task.FromResult(processor());
			}
			catch (System.Exception ex)
			{
				return Task.FromException<TResponse>(ex);
			}
		}

		/// <summary>
		/// Turn a processor to a dummy task.
		/// </summary>
		/// <param name="processor"></param>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <typeparam name="TRequest"></typeparam>
		/// <returns></returns>
		public static Task ConvertToTask<TRequest>(Action<TRequest> processor,
			TRequest request,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			try
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}

				processor(request);
				return Task.CompletedTask;
			}
			catch (System.Exception ex)
			{
				return Task.FromException(ex);
			}
		}

		/// <summary>
		/// Turn a processor to a dummy task.
		/// </summary>
		/// <param name="processor"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public static Task ConvertToTask(Action processor,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			try
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return Task.FromCanceled(cancellationToken);
				}

				processor();
				return Task.CompletedTask;
			}
			catch (System.Exception ex)
			{
				return Task.FromException(ex);
			}
		}
	}
}