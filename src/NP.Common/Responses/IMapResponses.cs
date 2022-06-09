namespace NP.Common.Responses
{
	/// <summary>
	/// Implementors will Map Responses from <see cref="IResponse"/> to <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IMapResponses<out T>
	{
		/// <summary>
		/// Map a <paramref name="response"/> to <typeparamref name="T"/>.
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		T Map(IResponse response);

		/// <summary>
		/// Map a <paramref name="response"/> to <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="TData"></typeparam>
		/// <param name="response"></param>
		/// <returns></returns>
		T Map<TData>(IResponse<TData> response);
	}
}