using System;
using System.Linq;

namespace NP.Common.Extensions
{
	/// <summary>
	/// Extensions for <see cref="Type"/>.
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Does <paramref name="thisType"/> implement <typeparamref name="TInterface"/>.
		/// </summary>
		/// <typeparam name="TInterface">The interface type that has been inherited.</typeparam>
		/// <param name="thisType">The type that needs to implement <typeparamref name="TInterface"/>.</param>
		/// <returns>True when <paramref name="thisType"/> implements <typeparamref name="TInterface"/>.</returns>
		public static bool HasInterface<TInterface>(this Type @thisType)
		{
			return @thisType.HasInterface(typeof(TInterface));
		}

		/// <summary>
		/// Does <paramref name="thisType"/> implement <paramref name="interfaceType"/>.
		/// </summary>
		/// <param name="thisType">The type that needs to implement <paramref name="interfaceType"/>.</param>
		/// <param name="interfaceType">The interface type that has been inherited.</param>
		/// <returns>True when <paramref name="thisType"/> implements <paramref name="interfaceType"/>.</returns>
		public static bool HasInterface(this Type @thisType, Type interfaceType)
		{

			return interfaceType.IsAssignableFrom(@thisType) ||
				   @thisType.GetInterfaces().Any(item => item == interfaceType
														 || item.IsGenericType
															 && item.GetGenericTypeDefinition() == interfaceType);
		}

		/// <summary>
		/// Is this type a <see cref="Nullable{T}"/> ?
		/// </summary>
		/// <param name="thisType"></param>
		/// <returns></returns>
		public static bool IsNullable(this Type @thisType)
		{
			return @thisType.IsGenericType
				&& @thisType.GetGenericTypeDefinition() == typeof(Nullable<>);
		}
	}
}
