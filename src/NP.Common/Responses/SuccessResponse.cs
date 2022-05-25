namespace NP.Common.Responses
{
	/// <summary>
	/// A successful response.
	/// </summary>
	public class SuccessResponse: IResponse
	{
		/// <inheritdoc cref="Message"/>
		public string Message { get; }

		/// <summary>
		/// Constructs the <see cref="SuccessResponse"/>
		/// </summary>
		public SuccessResponse() : this(string.Empty)
		{
			
		}

		/// <summary>
		/// Constructs the <see cref="SuccessResponse"/> with a <paramref name="message"/>.
		/// </summary>
		/// <param name="message"></param>
		public SuccessResponse(string message)
		{
			Message = message;
		}

		/// <inheritdoc cref="CastTo{TData}"/>
		public IResponse<TData> CastTo<TData>(Maybe<TData> data)
		{
			return new SuccessResponse<TData>(data);
		}
	}

	/// <summary>
	///  A successful response.
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public class SuccessResponse<TData> : SuccessResponse, IResponse<TData>
	{
		/// <inheritdoc />
		public Maybe<TData> Payload { get; }

		/// <summary>
		/// Constructs <see cref="SuccessResponse{Data}"/>
		/// </summary>
		public SuccessResponse() : base()
		{
			
		}

		/// <summary>
		/// Constructs <see cref="SuccessResponse{Data}"/> with a message and no payload.
		/// </summary>
		public SuccessResponse(string message): this(message, Maybe<TData>.Empty)
		{
			
		}

		/// <summary>
		/// Constructs <see cref="SuccessResponse{Data}"/> with payload and no message.
		/// </summary>
		public SuccessResponse(Maybe<TData> payload) :this(string.Empty, payload)
		{
			
		}

		/// <summary>
		/// Constructs <see cref="SuccessResponse{Data}"/> with a message and a payload.
		/// </summary>
		public SuccessResponse(string message, Maybe<TData> payload): base(message)
		{
			Payload = payload;
		}
	}
}