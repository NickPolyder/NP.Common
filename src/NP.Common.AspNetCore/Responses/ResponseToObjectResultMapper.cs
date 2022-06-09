using System.Net;
using Microsoft.AspNetCore.Mvc;
using NP.Common.Responses;

namespace NP.Common.AspNetCore.Responses
{
	/// <summary>
	/// 
	/// </summary>
	public class ResponseToObjectResultMapper: IMapResponses<IActionResult>
	{
		/// <inheritdoc />
		public IActionResult Map(IResponse response)
		{
			switch (response)
			{
				case SuccessResponse successResponse:
					return new OkObjectResult(successResponse.Message);
				
			}

			return new ObjectResult(null)
			{
				StatusCode = (int)HttpStatusCode.InternalServerError
			};
		}

		/// <inheritdoc />
		public IActionResult Map<TData>(IResponse<TData> response)
		{
			switch (response)
			{
				case SuccessResponse<TData> successResponse when successResponse.Payload.HasValue:
					return new OkObjectResult(successResponse.Payload.Value);

			}

			return new ObjectResult(null)
			{
				StatusCode = (int)HttpStatusCode.InternalServerError
			};
		}
	}
}