namespace NP.Common.Responses
{
	using System;
	using System.IO;
	using System.Runtime.Serialization;

	namespace NP.Common.Responses
	{
		/// <summary>
		/// A stream content response.
		/// </summary>
		[Serializable]
		public class ByteContentResponse : IResponse
		{
			/// <summary>
			/// Default Content Type for Byte Array Content
			/// </summary>
			public const string DefaultContentType = "application/octet-stream";

			/// <inheritdoc cref="Message"/>
			public string Message { get; }

			/// <summary>
			/// 
			/// </summary>
			public byte[] Content { get; }

			/// <summary>
			/// 
			/// </summary>
			public string ContentType { get; }

			/// <summary>
			/// Constructs the <see cref="ByteContentResponse"/>
			/// </summary>
			public ByteContentResponse() : this(string.Empty)
			{

			}

			/// <summary>
			/// Constructs the <see cref="ByteContentResponse"/> with a <paramref name="message"/>.
			/// </summary>
			/// <param name="message"></param>
			public ByteContentResponse(string message) : this(message, Array.Empty<byte>(), DefaultContentType)
			{
			}

			/// <summary>
			/// Constructs the <see cref="ByteContentResponse"/> with <paramref name="content"/> and <paramref name="contentType"/>.
			/// </summary>
			/// <param name="content"></param>
			/// <param name="contentType"></param>
			public ByteContentResponse(byte[] content, string contentType) : this(string.Empty, content, contentType)
			{
			}

			/// <summary>
			/// Constructs the <see cref="ByteContentResponse"/> with a <paramref name="message"/>, <paramref name="content"/> and <paramref name="contentType"/>.
			/// </summary>
			/// <param name="message"></param>
			/// <param name="content"></param>
			/// <param name="contentType"></param>
			public ByteContentResponse(string message, byte[] content, string contentType)
			{
				Message = message;
				Content = content ?? Array.Empty<byte>();
				ContentType = contentType ?? DefaultContentType;
			}

			/// <inheritdoc cref="CastTo{TData}"/>
			public IResponse<TData> CastTo<TData>(Maybe<TData> data)
			{
				return new ByteContentResponse<TData>(Message, Content, ContentType);
			}

			#region Serialization

			/// <summary>
			/// Serialization Constructor
			/// </summary>
			/// <param name="info"></param>
			/// <param name="context"></param>
			protected ByteContentResponse(SerializationInfo info, StreamingContext context)
			{
				Message = info.GetString(nameof(Message));
				ContentType = info.GetString(nameof(ContentType));
				Content = info.GetValue(nameof(Content), typeof(byte[])) is byte[] content ? content : Array.Empty<byte>();

			}

			/// <inheritdoc />
			public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
			{
				info.AddValue(nameof(Message), Message);
				info.AddValue(nameof(ContentType), ContentType);
				info.AddValue(nameof(Content), Content, typeof(byte[]));
			}

			#endregion
		}

		/// <summary>
		///  A stream content response.
		/// </summary>
		/// <typeparam name="TData"></typeparam>
		public class ByteContentResponse<TData> : ByteContentResponse, IResponse<TData>
		{

			/// <summary>
			/// Constructs <see cref="ByteContentResponse{Data}"/>
			/// </summary>
			public ByteContentResponse() : base()
			{

			}

			/// <summary>
			/// Constructs <see cref="ByteContentResponse{Data}"/> with a message and no Stream Content.
			/// </summary>
			public ByteContentResponse(string message) : this(message, Array.Empty<byte>(), DefaultContentType)
			{

			}

			/// <summary>
			/// Constructs the <see cref="ByteContentResponse{TData}"/> with <paramref name="content"/> and <paramref name="contentType"/>.
			/// </summary>
			/// <param name="content"></param>
			/// <param name="contentType"></param>
			public ByteContentResponse(byte[] content, string contentType) : this(string.Empty, content, contentType)
			{
			}

			/// <summary>
			/// Constructs the <see cref="ByteContentResponse{TData}"/> with a <paramref name="message"/>, <paramref name="content"/> and <paramref name="contentType"/>.
			/// </summary>
			/// <param name="message"></param>
			/// <param name="content"></param>
			/// <param name="contentType"></param>
			public ByteContentResponse(string message, byte[] content, string contentType) : base(message, content, contentType)
			{
			}

			#region Serialization

			/// <summary>
			/// Serialization Constructor
			/// </summary>
			/// <param name="info"></param>
			/// <param name="context"></param>
			protected ByteContentResponse(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}


			#endregion
		}
	}
}