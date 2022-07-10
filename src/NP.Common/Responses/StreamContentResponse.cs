using System;
using System.IO;
using System.Runtime.Serialization;

namespace NP.Common.Responses
{
	/// <summary>
	/// A stream content response.
	/// </summary>
	[Serializable]
	public class StreamContentResponse : IResponse
	{
		/// <summary>
		/// Default Content Type for Stream Content
		/// </summary>
		public const string DefaultContentType = "application/octet-stream";

		/// <inheritdoc cref="Message"/>
		public string Message { get; }

		/// <summary>
		/// 
		/// </summary>
		public Stream Content { get; }

		/// <summary>
		/// 
		/// </summary>
		public string ContentType { get; }

		/// <summary>
		/// Constructs the <see cref="StreamContentResponse"/>
		/// </summary>
		public StreamContentResponse() : this(string.Empty)
		{
			
		}

		/// <summary>
		/// Constructs the <see cref="StreamContentResponse"/> with a <paramref name="message"/>.
		/// </summary>
		/// <param name="message"></param>
		public StreamContentResponse(string message): this(message, Stream.Null, DefaultContentType)
		{
		}

		/// <summary>
		/// Constructs the <see cref="StreamContentResponse"/> with <paramref name="content"/> and <paramref name="contentType"/>.
		/// </summary>
		/// <param name="content"></param>
		/// <param name="contentType"></param>
		public StreamContentResponse(Stream content, string contentType): this(string.Empty, content, contentType)
		{
		}

		/// <summary>
		/// Constructs the <see cref="StreamContentResponse"/> with a <paramref name="message"/>, <paramref name="content"/> and <paramref name="contentType"/>.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="content"></param>
		/// <param name="contentType"></param>
		public StreamContentResponse(string message, Stream content, string contentType)
		{
			Message = message;
			Content = content ?? Stream.Null;
			ContentType = contentType ?? DefaultContentType;
		}

		/// <inheritdoc cref="CastTo{TData}"/>
		public IResponse<TData> CastTo<TData>(Maybe<TData> data)
		{
			return new StreamContentResponse<TData>(Message, Content, ContentType);
		}

		#region Serialization
		
		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected StreamContentResponse(SerializationInfo info, StreamingContext context)
		{
			Message = info.GetString(nameof(Message));
			ContentType = info.GetString(nameof(ContentType));
			Content = info.GetValue(nameof(Content), typeof(Stream)) is Stream content ? content : Stream.Null;

		}

		/// <inheritdoc />
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(Message), Message);
			info.AddValue(nameof(ContentType), ContentType);
			info.AddValue(nameof(Content), Content, typeof(Stream));
		}

		#endregion
	}

	/// <summary>
	///  A stream content response.
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public class StreamContentResponse<TData> : StreamContentResponse, IResponse<TData>
	{

		/// <summary>
		/// Constructs <see cref="StreamContentResponse{Data}"/>
		/// </summary>
		public StreamContentResponse() : base()
		{
			
		}

		/// <summary>
		/// Constructs <see cref="StreamContentResponse{Data}"/> with a message and no Stream Content.
		/// </summary>
		public StreamContentResponse(string message): this(message, Stream.Null, DefaultContentType)
		{
			
		}

		/// <summary>
		/// Constructs the <see cref="StreamContentResponse{TData}"/> with <paramref name="content"/> and <paramref name="contentType"/>.
		/// </summary>
		/// <param name="content"></param>
		/// <param name="contentType"></param>
		public StreamContentResponse(Stream content, string contentType) : this(string.Empty, content, contentType)
		{
		}

		/// <summary>
		/// Constructs the <see cref="StreamContentResponse{TData}"/> with a <paramref name="message"/>, <paramref name="content"/> and <paramref name="contentType"/>.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="content"></param>
		/// <param name="contentType"></param>
		public StreamContentResponse(string message, Stream content, string contentType) : base(message, content, contentType)
		{
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected StreamContentResponse(SerializationInfo info, StreamingContext context): base(info, context)
		{
		}
		

		#endregion
	}
}