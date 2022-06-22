using System;
using System.Runtime.Serialization;

namespace NP.Common.Responses
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class NotAuthorizedResponse : IResponse
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
		public NotAuthorizedResponse() : this(string.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public NotAuthorizedResponse(string message) : this(message, string.Empty)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		public NotAuthorizedResponse(string message, string resource)
		{
			Message = message;
			Resource = resource;
		}
		/// <inheritdoc />
		public IResponse<TData> CastTo<TData>(Maybe<TData> data)
		{
			return new NotAuthorizedResponse<TData>(Message, Resource);
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected NotAuthorizedResponse(SerializationInfo info, StreamingContext context)
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
	[Serializable]
	public class NotAuthorizedResponse<TData> : NotAuthorizedResponse, IResponse<TData>
	{
		/// <summary>
		/// 
		/// </summary>
		public NotAuthorizedResponse() : base()
		{

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public NotAuthorizedResponse(string message) : this(message, string.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		public NotAuthorizedResponse(string message, string resource) : base(message, resource)
		{
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected NotAuthorizedResponse(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		#endregion
	}
}