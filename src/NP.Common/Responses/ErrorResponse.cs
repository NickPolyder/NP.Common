using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace NP.Common.Responses
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class ErrorResponse : IResponse
	{
		/// <inheritdoc />
		public string Message { get; }

		/// <summary>
		/// 
		/// </summary>
		public IEnumerable<ErrorEntry> Errors { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public ErrorResponse(string message) : this(message, null)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="errors"></param>
		public ErrorResponse(IEnumerable<ErrorEntry> errors) : this(null, errors)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errors"></param>
		public ErrorResponse(string message, IEnumerable<ErrorEntry> errors)
		{
			Errors = errors ?? Enumerable.Empty<ErrorEntry>();
			Message = message ?? Errors.FirstOrDefault()?.Message;
		}
		/// <inheritdoc />
		public IResponse<TData> CastTo<TData>(Maybe<TData> data)
		{
			return new ErrorResponse<TData>(Message, Errors);
		}

		#region Serialization

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ErrorResponse(SerializationInfo info, StreamingContext context)
		{
			Errors = info.GetValue(nameof(Errors), typeof(ErrorEntry[])) is IEnumerable<ErrorEntry> entries
				? entries
				: Enumerable.Empty<ErrorEntry>();

			Message = info.GetString(nameof(Message)) ?? Errors.FirstOrDefault()?.Message;
		}

		/// <inheritdoc />
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(Message), Message);
			if (Errors != null)
			{
				var array = Errors.ToArray();
				info.AddValue(nameof(Errors), array, typeof(ErrorEntry[]));
			}
		}

		#endregion
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	[Serializable]
	public class ErrorResponse<TData> : ErrorResponse, IResponse<TData>
	{

		/// <inheritdoc />
		public ErrorResponse(string message) : this(message, Array.Empty<ErrorEntry>())
		{
		}

		/// <inheritdoc />
		public ErrorResponse(IEnumerable<ErrorEntry> errors) : this(string.Empty, errors)
		{
		}

		/// <inheritdoc />
		public ErrorResponse(string message, IEnumerable<ErrorEntry> errors) : base(message, errors)
		{
		}

		#region Serialization

		/// <inheritdoc />
		protected ErrorResponse(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		#endregion
	}
}