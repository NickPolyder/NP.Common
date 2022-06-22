using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NP.Common.Responses;

namespace NP.Common.AspNetCore.Extensions
{
	/// <summary>
	/// Controller Extensions.
	/// </summary>
	public static class ControllerExtensions
	{
		/// <summary>
		/// Maps a <paramref name="response"/> to an <see cref="IActionResult"/>.
		/// </summary>
		/// <param name="response"></param>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IActionResult ToActionResult(this IResponse response, IServiceProvider services)
		{
			var mapper = services.GetRequiredService<IMapResponses<IActionResult>>();
			return mapper.Map(response);
		}

		/// <summary>
		/// Maps a <paramref name="response"/> to an <see cref="IActionResult"/>.
		/// </summary>
		/// <param name="response"></param>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IActionResult ToActionResult<TData>(this IResponse<TData> response, IServiceProvider services)
		{
			var mapper = services.GetRequiredService<IMapResponses<IActionResult>>();
			return mapper.Map(response);
		}

	}
}