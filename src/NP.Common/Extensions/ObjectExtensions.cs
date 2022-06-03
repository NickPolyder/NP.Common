namespace NP.Common.Extensions
{
	/// <summary>
	/// 
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Cast <typeparamref name="TFrom"/> to <typeparamref name="TTo"/>.
		/// </summary>
		/// <typeparam name="TFrom"></typeparam>
		/// <typeparam name="TTo"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static TTo As<TFrom, TTo>(this TFrom obj)
		{
			if(obj is TTo y)
			{
				return y;
			}

			return default(TTo);
		}
	}
}