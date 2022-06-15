using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace NP.Common.Responses
{
	/// <summary>
	/// An Aggregate Result
	/// </summary>
	[Serializable]
	public class AggregateResponse: IResponse
	{
		
		/// <inheritdoc />
		public string Message { get; }

		/// <summary>
		/// A collection of Responses.
		/// </summary>
		public IEnumerable<IResponse> Responses { get; }

		/// <summary>
		/// 
		/// </summary>
		public AggregateResponse()
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public AggregateResponse(string message): this(message, Array.Empty<IResponse>())
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="responses"></param>
		public AggregateResponse(string message, IEnumerable<IResponse> responses)
		{
			Message = message;
			Responses = responses ?? Array.Empty<IResponse>();
		}

		/// <inheritdoc />
		public IResponse<TData> CastTo<TData>(Maybe<TData> data)
		{
			return new AggregateResponse<TData>(Message, Responses);
		}

		/// <summary>
		/// Are All of the responses are of type <typeparamref name="TResponse"/> ?
		/// </summary>
		/// <typeparam name="TResponse"></typeparam>
		/// <returns>true when all of the responses are of type <typeparamref name="TResponse"/>.</returns>
		public bool All<TResponse>() where TResponse : IResponse
		{
			return Responses.All(item => item is TResponse);
		}

		/// <summary>
		/// Responses contain at least one of type <typeparamref name="TResponse"/> 
		/// </summary>
		/// <typeparam name="TResponse"></typeparam>
		/// <returns>true when the <typeparamref name="TResponse"/> exists in the responses.</returns>
		public bool Contains<TResponse>() where TResponse : IResponse
		{
			return Responses.Any(item => item is TResponse);
		}

		#region Serialization

			/// <summary>
			/// Serialization Constructor
			/// </summary>
			/// <param name="info"></param>
			/// <param name="context"></param>
		protected AggregateResponse(SerializationInfo info, StreamingContext context)
		{
			Message = info.GetString(nameof(Message));
			Responses = info.GetValue(nameof(Responses), typeof(IResponse[])) is IResponse[] responses ? responses : Array.Empty<IResponse>();

		}

		/// <inheritdoc />
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(Message), Message);
			info.AddValue(nameof(Responses), Responses?.ToArray(), typeof(IResponse[]));
		}

		#endregion
	}

	/// <summary>
	/// An Aggregate Result of <typeparamref name="TData"/>
	/// </summary>
	public class AggregateResponse<TData> : AggregateResponse, IResponse<TData>
	{
		/// <summary>
		/// 
		/// </summary>
		public AggregateResponse()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public AggregateResponse(string message) : this(message, Array.Empty<IResponse>())
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="responses"></param>
		public AggregateResponse(string message, IEnumerable<IResponse> responses): base(message, responses)
		{
		}

		
		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AggregateResponse(SerializationInfo info, StreamingContext context): base(info, context)
		{
			
		}
		
		#endregion
	}
}