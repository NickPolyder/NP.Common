namespace NP.Common.Extensions
{
	/// <summary>
	/// Maybe Extensions.
	/// </summary>
	public static class MaybeExtensions
	{
		/// <summary>
		/// Convert value to a <see cref="Maybe{T}"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Maybe<T> AsMaybe<T>(this T value)
		{
			if (value == null)
			{
				return Maybe<T>.Empty;
			}

			return Maybe<T>.WithValue(value);
		}
	}
}