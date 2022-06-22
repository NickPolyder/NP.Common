using System;
using System.Runtime.Serialization;
using NP.Common.Responses;

namespace NP.Common.Responses
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class NotSupportedResponse: IResponse
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
		public NotSupportedResponse() : this(string.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public NotSupportedResponse(string message) : this(message, string.Empty)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		public NotSupportedResponse(string message, string resource)
		{
			Message = message;
			Resource = resource;
		}
		/// <inheritdoc />
		public IResponse<TData> CastTo<TData>(Maybe<TData> data)
		{
			return new NotSupportedResponse<TData>(Message, Resource);
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected NotSupportedResponse(SerializationInfo info, StreamingContext context)
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
	public class NotSupportedResponse<TData> : NotSupportedResponse, IResponse<TData>
	{
		/// <summary>
		/// 
		/// </summary>
		public NotSupportedResponse() : base()
		{

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public NotSupportedResponse(string message) : this(message, string.Empty)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="resource"></param>
		public NotSupportedResponse(string message, string resource) : base(message, resource)
		{
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected NotSupportedResponse(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		#endregion
	}
}