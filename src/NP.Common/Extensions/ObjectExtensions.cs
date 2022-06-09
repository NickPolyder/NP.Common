namespace NP.Common.Extensions
{
	/// <summary>
	/// 
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Cast <paramref name="obj"/> to <typeparamref name="TTo"/>.
		/// </summary>
		/// <typeparam name="TTo"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static TTo As<TTo>(this object obj)
		{
			if(obj is TTo y)
			{
				return y;
			}

			return default(TTo);
		}

		/// <summary>
		/// Checks if the object is null.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsNull(this object obj) => obj  == null;
	}
}