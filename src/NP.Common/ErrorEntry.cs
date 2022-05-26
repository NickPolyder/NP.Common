using System;
using System.Runtime.Serialization;

namespace NP.Common
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class ErrorEntry : ISerializable
	{
		/// <summary>
		/// 
		/// </summary>
		public ushort Severity { get; }

		/// <summary>
		/// 
		/// </summary>
		public string RelatedTo { get; }

		/// <summary>
		/// 
		/// </summary>
		public string Message { get; }

		/// <summary>
		/// 
		/// </summary>
		public Exception Exception { get; }
		

		/// <summary>
		/// Constructs a <see cref="ErrorEntry"/> instance.
		/// </summary>
		/// <param name="severity"></param>
		/// <param name="relatedTo"></param>
		/// <param name="message"></param>
		/// <param name="exception"></param>
		public ErrorEntry(ushort severity, string relatedTo, string message, Exception exception)
		{
			Severity = severity;
			RelatedTo = relatedTo;
			Message = message ?? exception?.Message;
			Exception = exception;
		}

		#region Serialization
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ErrorEntry(SerializationInfo info, StreamingContext context)
		{
			Severity = info.GetUInt16(nameof(Severity));
			RelatedTo = info.GetString(nameof(RelatedTo));
			Message = info.GetString(nameof(Message));
			Exception = info.GetValue(nameof(Exception), typeof(Exception)) as Exception;
		}
		/// <inheritdoc />
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(Severity), Severity);
			info.AddValue(nameof(RelatedTo), RelatedTo);
			info.AddValue(nameof(Message), Message);
			if (Exception != null)
			{
				info.AddValue(nameof(Exception), Exception, Exception.GetType());
			}
		}

		#endregion

		#region Builder

		/// <summary>
		/// A builder object for the <see cref="ErrorEntry"/>.
		/// </summary>
		public class Builder
		{
			private ushort _severity;
			private string _relatedTo;
			private string _message;
			private Exception _exception;

			/// <summary>
			/// 
			/// </summary>
			public Builder SetSeverity(ushort severity)
			{
				_severity = severity;
				return this;
			}

			/// <summary>
			/// 
			/// </summary>
			public Builder SetRelatedTo(string relatedTo)
			{
				_relatedTo = relatedTo;
				return this;
			}

			/// <summary>
			/// 
			/// </summary>
			public Builder SetMessage(string message)
			{
				_message = message;
				return this;
			}

			/// <summary>
			/// 
			/// </summary>
			public Builder SetException(Exception exception)
			{
				_exception = exception;
				return this;
			}

			/// <summary>
			/// Builds an Error Entry.
			/// </summary>
			/// <returns>The built ErrorEntry.</returns>
			public ErrorEntry Build()
			{
				var finalRelatedTo = _relatedTo;
				var finalMessage = _message;

				if (_exception != null)
				{
					if (string.IsNullOrWhiteSpace(finalRelatedTo) && _exception is ArgumentException argumentException)
					{
						finalRelatedTo = argumentException.ParamName;
					}

					if (string.IsNullOrWhiteSpace(finalMessage))
					{
						finalMessage = _exception.Message;
					}
				}else if (string.IsNullOrWhiteSpace(finalMessage))
				{
					throw new ArgumentNullException(nameof(finalMessage));
				}
				
				return new ErrorEntry(_severity, finalRelatedTo, finalMessage, _exception);
			}
		}

		#endregion
	}
}