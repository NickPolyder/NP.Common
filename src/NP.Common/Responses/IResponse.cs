using System.Runtime.Serialization;

namespace NP.Common.Responses
{
	/// <summary>
	/// A Contract for Responses.
	/// </summary>
	public interface IResponse: ISerializable
	{
		/// <summary>
		/// Information about the response.
		/// </summary>
		string Message { get; }
		
		/// <summary>
		/// Casts the Response to its generic counterpart.
		/// </summary>
		/// <param name="data"></param>
		/// <typeparam name="TData"></typeparam>
		/// <returns>The Generic Response.</returns>
		IResponse<TData> CastTo<TData>(Maybe<TData> data);
	}

	/// <summary>
	/// A Contract for Responses that contain a Payload of type <typeparamref name="TData"/>.
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public interface IResponse<TData> : IResponse
	{
	}
}