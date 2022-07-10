using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NP.Common.AspNetCore.Responses;
using NP.Common.Responses;

namespace NP.Common.AspNetCore
{
	/// <summary>
	/// Dependency Injection Extensions
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Adds all the NpCommon related services.
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddNpCommon(this IServiceCollection services)
		{
			services.TryAddScoped<IMapResponses<IActionResult>, ResponseToObjectResultMapper>();

			return services;
		}
	}
}