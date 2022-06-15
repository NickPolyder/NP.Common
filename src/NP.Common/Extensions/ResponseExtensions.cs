using NP.Common.Responses;

namespace NP.Common.Extensions
{
	/// <summary>
	/// 
	/// </summary>
	public static class ResponseExtensions
	{

		/// <summary>
		/// Casts the Response to its generic counterpart.
		/// </summary>
		/// <typeparam name="TData"></typeparam>
		/// <returns>The Generic Response.</returns>
		public static IResponse<TData> CastTo<TData>(this IResponse response) => response.CastTo<TData>(Maybe<TData>.Empty);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		/// <returns>Itself</returns>
		public static WhenBuilder When(this IResponse response) => new WhenBuilder(response);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		/// <returns>Itself</returns>
		public static WhenBuilder<TData> When<TData>(this IResponse<TData> response) => new WhenBuilder<TData>(response);
	}

}
