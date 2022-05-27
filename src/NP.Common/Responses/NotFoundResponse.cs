using System;
using System.Runtime.Serialization;

namespace NP.Common.Responses
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class NotFoundResponse : IResponse
	{
		/// <inheritdoc />
		public string Message { get; }

		/// <summary>
		/// The Resource requested.
		/// </summary>
		public string Resource { get; }

		/// <summary>
		/// 
		/// </summary>
		public NotFoundResponse() : this(string.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public NotFoundResponse(string message) : this(message, string.Empty)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		public NotFoundResponse(string message, string resource)
		{
			Message = message;
			Resource = resource;
		}
		/// <inheritdoc />
		public IResponse<TData> CastTo<TData>(Maybe<TData> data)
		{
			return new NotFoundResponse<TData>(Message, Resource, data);
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected NotFoundResponse(SerializationInfo info, StreamingContext context)
		{
			Message = info.GetString(nameof(Message));
			Resource = info.GetString(nameof(Resource));

		}

		/// <inheritdoc />
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(Message), Message);
			info.AddValue(nameof(Resource), Resource);
		}

		#endregion
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	[Serializable]
	public class NotFoundResponse<TData> : NotFoundResponse, IResponse<TData>
	{
		/// <inheritdoc />
		public Maybe<TData> Payload { get; }

		/// <summary>
		/// 
		/// </summary>
		public NotFoundResponse() : base()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public NotFoundResponse(Maybe<TData> data) : this(string.Empty, data)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public NotFoundResponse(string message) : this(message, Maybe<TData>.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="data"></param>
		public NotFoundResponse(string message, Maybe<TData> data) : this(message, string.Empty, data)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		public NotFoundResponse(string message, string resource) : this(message, resource, Maybe<TData>.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		/// <param name="data"></param>
		public NotFoundResponse(string message, string resource, Maybe<TData> data) : base(message, resource)
		{
			Payload = data;
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected NotFoundResponse(SerializationInfo info, StreamingContext context) : base(info, context)
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