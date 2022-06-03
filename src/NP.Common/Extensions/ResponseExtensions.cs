using System;
using System.Threading;
using System.Threading.Tasks;
using NP.Common.Responses;

namespace NP.Common.Extensions
{
	/// <summary>
	/// 
	/// </summary>
	public static class ResponseExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		/// <returns>Itself</returns>
		public static WhenBuilder When(this IResponse response) => new WhenBuilder(response);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		/// <returns>Itself</returns>
		public static WhenBuilder<TData> When<TData>(this IResponse<TData> response) => new WhenBuilder<TData>(response);
	}

	/// <summary>
	/// When Builder with <typeparamref name="TData"/>.
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public class WhenBuilder<TData>
	{
		private readonly IResponse<TData> _request;

		private IResponse _response;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="request"></param>
		public WhenBuilder(IResponse<TData> request)
		{
			_request = request;
			_response = request;
		}

		/// <summary>
		/// Executes the <paramref name="processor"/> and saves the result.
		/// </summary>
		/// <param name="processor">the action to execute.</param>
		/// <returns>Itself</returns>
		public WhenBuilder<TData> Execute(Func<IResponse<TData>, IResponse> processor)
		{
			_response = processor(_request);
			return this;
		}

		/// <summary>
		/// Executes the <paramref name="processor"/> and saves the result.
		/// </summary>
		/// <param name="processor">the action to execute.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Itself</returns>
		public async Task<WhenBuilder<TData>> ExecuteAsync(Func<IResponse<TData>, CancellationToken, Task<IResponse>> processor, CancellationToken cancellationToken = default)
		{
			_response = await processor(_request, cancellationToken);
			return this;
		}

		/// <summary>
		/// Maps to <see cref="IResponse{TOtherData}"/> by executing the <paramref name="processor"/>.
		/// </summary>
		/// <param name="processor">the action to execute.</param>
		/// <returns>Itself</returns>
		public WhenBuilder<TData> Execute<TOtherData>(Func<IResponse<TData>, IResponse<TOtherData>> processor)
		{
			_response = processor(_request);
			return this;
		}

		/// <summary>
		/// Maps to <see cref="IResponse{TOtherData}"/> by executing the <paramref name="processor"/>.
		/// </summary>
		/// <param name="processor">the action to execute.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Itself</returns>
		public async Task<WhenBuilder<TData>> ExecuteAsync<TOtherData>(Func<IResponse<TData>, CancellationToken, Task<IResponse<TOtherData>>> processor, CancellationToken cancellationToken = default)
		{
			_response = await processor(_request, cancellationToken);
			return this;
		}

		/// <summary>
		/// Executes the <paramref name="processor"/> If the request is of type <typeparamref name="TConcrete"/> and saves the result.
		/// </summary>
		/// <typeparam name="TConcrete">The Concrete type that the request has to be.</typeparam>
		/// <param name="processor">the action to execute.</param>
		/// <returns>Itself</returns>
		public WhenBuilder<TData> ExecuteIf<TConcrete>(Func<TConcrete, IResponse> processor) where TConcrete : IResponse<TData>
		{
			if (_request is TConcrete concrete)
			{
				_response = processor(concrete);
			}

			return this;
		}

		/// <summary>
		/// Executes the <paramref name="processor"/> If the request is of type <typeparamref name="TConcrete"/> and saves the result.
		/// </summary>
		/// <typeparam name="TConcrete">The Concrete type that the request has to be.</typeparam>
		/// <param name="processor">the action to execute.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Itself</returns>
		public async Task<WhenBuilder<TData>> ExecuteIfAsync<TConcrete>(Func<TConcrete, CancellationToken, Task<IResponse>> processor, CancellationToken cancellationToken = default) where TConcrete : IResponse<TData>
		{
			if (_request is TConcrete concrete)
			{
				_response = await processor(concrete, cancellationToken);
			}

			return this;
		}

		/// <summary>
		/// Maps to <see cref="IResponse{TOtherData}"/> If the type is of type <typeparamref name="TConcrete"/> by executing the <paramref name="processor"/>.
		/// </summary>
		/// <typeparam name="TConcrete">The Concrete type that the request has to be.</typeparam>
		/// <typeparam name="TOtherData"></typeparam>
		/// <param name="processor">the action to execute.</param>
		/// <returns>Itself</returns>
		public WhenBuilder<TData> ExecuteIf<TConcrete, TOtherData>(Func<TConcrete, IResponse<TOtherData>> processor) where TConcrete : IResponse<TData>
		{
			if (_request is TConcrete concrete)
			{
				_response = processor(concrete);
			}

			return this;
		}

		/// <summary>
		/// Maps to <see cref="IResponse{TOtherData}"/> If the type is of type <typeparamref name="TConcrete"/> by executing the <paramref name="processor"/>.
		/// </summary>
		/// <typeparam name="TConcrete">The Concrete type that the request has to be.</typeparam>
		/// <typeparam name="TOtherData"></typeparam>
		/// <param name="processor">the action to execute.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Itself</returns>
		public async Task<WhenBuilder<TData>> ExecuteIfAsync<TConcrete, TOtherData>(Func<TConcrete, CancellationToken, Task<IResponse<TOtherData>>> processor, CancellationToken cancellationToken = default) where TConcrete : IResponse<TData>
		{
			if (_request is TConcrete concrete)
			{
				_response = await processor(concrete, cancellationToken);
			}

			return this;
		}

		/// <summary>
		/// Executes the <paramref name="processor"/> If not the request is of type <typeparamref name="TConcrete"/> and saves the result. 
		/// </summary>
		/// <typeparam name="TConcrete">The Concrete type that the request has to be.</typeparam>
		/// <param name="processor">the action to execute.</param>
		/// <returns>Itself</returns>
		public WhenBuilder<TData> ExecuteIfNot<TConcrete>(Func<IResponse<TData>, IResponse> processor) where TConcrete : IResponse<TData>
		{
			if (!(_request is TConcrete))
			{
				_response = processor(_request);
			}

			return this;
		}

		/// <summary>
		/// Executes the <paramref name="processor"/> If not the request is of type <typeparamref name="TConcrete"/> and saves the result. 
		/// </summary>
		/// <typeparam name="TConcrete">The Concrete type that the request has to be.</typeparam>
		/// <param name="processor">the action to execute.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Itself</returns>
		public async Task<WhenBuilder<TData>> ExecuteIfNotAsync<TConcrete>(Func<IResponse<TData>, CancellationToken, Task<IResponse>> processor, CancellationToken cancellationToken = default) where TConcrete : IResponse<TData>
		{
			if (!(_request is TConcrete))
			{
				_response = await processor(_request, cancellationToken);
			}

			return this;
		}

		/// <summary>
		/// Maps to <see cref="IResponse{TOtherData}"/> If not the type is of type <typeparamref name="TConcrete"/> by executing the <paramref name="processor"/>.
		/// </summary>
		/// <typeparam name="TConcrete">The Concrete type that the request has to be.</typeparam>
		/// <typeparam name="TOtherData"></typeparam>
		/// <param name="processor">the action to execute.</param>
		/// <returns>Itself</returns>
		public WhenBuilder<TData> ExecuteIfNot<TConcrete, TOtherData>(Func<IResponse<TData>, IResponse<TOtherData>> processor) where TConcrete : IResponse<TData>
		{
			if (!(_request is TConcrete))
			{
				_response = processor(_request);
			}

			return this;
		}

		/// <summary>
		/// Maps to <see cref="IResponse{TOtherData}"/> If not the type is of type <typeparamref name="TConcrete"/> by executing the <paramref name="processor"/>.
		/// </summary>
		/// <typeparam name="TConcrete">The Concrete type that the request has to be.</typeparam>
		/// <typeparam name="TOtherData"></typeparam>
		/// <param name="processor">the action to execute.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Itself</returns>
		public async Task<WhenBuilder<TData>> ExecuteIfNotAsync<TConcrete, TOtherData>(Func<IResponse<TData>, CancellationToken, Task<IResponse<TOtherData>>> processor, CancellationToken cancellationToken = default) where TConcrete : IResponse<TData>
		{
			if (!(_request is TConcrete))
			{
				_response = await processor(_request, cancellationToken);
			}

			return this;
		}

		/// <returns>The modified response.</returns>
		public IResponse Return() => _response ?? _request;

		/// <returns>The modified mapped response.</returns>
		public IResponse<TOtherData> Return<TOtherData>() => Return<TOtherData>(Maybe<TOtherData>.Empty);
		
		/// <typeparam name="TOtherData"></typeparam>
		/// <param name="data"></param>
		/// <returns>The modified mapped response.</returns>
		public IResponse<TOtherData> Return<TOtherData>(Maybe<TOtherData> data)
		{
			var result = (_response ?? _request);
			if (result is IResponse<TOtherData> responseWithData)
			{
				return responseWithData;
			}

			return result?.CastTo(data);
		}
	}

}
