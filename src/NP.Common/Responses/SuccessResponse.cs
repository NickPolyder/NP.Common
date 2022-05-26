using System;
using System.Runtime.Serialization;

namespace NP.Common.Responses
{
	/// <summary>
	/// A successful response.
	/// </summary>
	[Serializable]
	public class SuccessResponse: IResponse, ISerializable
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
			return new SuccessResponse<TData>(Message, data);
		}

		#region Serialization
		
		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SuccessResponse(SerializationInfo info, StreamingContext context)
		{
			Message = info.GetString(nameof(Message));

		}

		/// <inheritdoc />
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(Message), Message);
		}

		#endregion
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

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SuccessResponse(SerializationInfo info, StreamingContext context): base(info, context)
		{
			Payload = info.GetValue(nameof(Payload), typeof(Maybe<TData>)) is Maybe<TData> data ? data : Maybe<TData>.Empty;
		}

		/// <inheritdoc />
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue(nameof(Payload), Payload, typeof(Maybe<TData>));
		}

		#endregion
	}
}