using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
				
				case NotFoundResponse notFoundResponse:
					return new NotFoundObjectResult(notFoundResponse.Message);
				
				case BadInputResponse badInputResponse:
					var modelState = new ModelStateDictionary();
					modelState.AddModelError(badInputResponse.Resource, badInputResponse.Message);
					return new BadRequestObjectResult(modelState);
				
				case ErrorResponse errorResponse:
					return new ObjectResult(errorResponse)
					{
						StatusCode = (int)HttpStatusCode.InternalServerError,
					};
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
				
				case NotFoundResponse<TData> notFoundResponse:
					return new NotFoundObjectResult(notFoundResponse.Message);
				
				case BadInputResponse<TData> badInputResponse:
					var modelState = new ModelStateDictionary();
					modelState.AddModelError(badInputResponse.Resource, badInputResponse.Message);
					return new BadRequestObjectResult(modelState);
				
				case ErrorResponse<TData> errorResponse:
					return new ObjectResult(errorResponse)
					{
						StatusCode = (int)HttpStatusCode.InternalServerError,
					};
			}

			return new ObjectResult(null)
			{
				StatusCode = (int)HttpStatusCode.InternalServerError
			};
		}
	}
}