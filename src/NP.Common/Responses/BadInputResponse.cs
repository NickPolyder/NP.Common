using System.Runtime.Serialization;

namespace NP.Common.Responses
{
	/// <summary>
	/// 
	/// </summary>
	public class BadInputResponse: IResponse
	{
		/// <summary>
		/// The Resource requested.
		/// </summary>
		public string Resource { get; }

		/// <inheritdoc />
		public string Message { get; }

		/// <summary>
		/// 
		/// </summary>
		public BadInputResponse() : this(string.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public BadInputResponse(string message) : this(message, string.Empty)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		public BadInputResponse(string message, string resource)
		{
			Message = message;
			Resource = resource;
		}

		/// <inheritdoc />
		public IResponse<TData> CastTo<TData>(Maybe<TData> data)
		{
			return new BadInputResponse<TData>(Message, Resource, data);
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected BadInputResponse(SerializationInfo info, StreamingContext context)
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
	public class BadInputResponse<TData> : BadInputResponse, IResponse<TData>
	{
		/// <summary>
		///  Data related to the result.
		/// </summary>
		public Maybe<TData> Payload { get; }

		/// <summary>
		/// 
		/// </summary>
		public BadInputResponse() : this(Maybe<TData>.Empty)
		{

		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		public BadInputResponse(Maybe<TData> data) : this(string.Empty, data)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public BadInputResponse(string message) : this(message, Maybe<TData>.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="data"></param>
		public BadInputResponse(string message, Maybe<TData> data) : this(message, string.Empty, data)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		public BadInputResponse(string message, string resource) : this(message, resource, Maybe<TData>.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		/// <param name="data"></param>
		public BadInputResponse(string message, string resource, Maybe<TData> data) : base(message, resource)
		{
			Payload = data;
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected BadInputResponse(SerializationInfo info, StreamingContext context): base(info, context)
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