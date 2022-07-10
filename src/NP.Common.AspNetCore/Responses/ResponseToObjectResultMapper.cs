using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NP.Common.Responses;

namespace NP.Common.AspNetCore.Responses
{
	/// <summary>
	/// 
	/// </summary>
	public class ResponseToObjectResultMapper : IMapResponses<IActionResult>
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

				case NotSupportedResponse notSupportedResponse:
					return new ObjectResult(notSupportedResponse.Message)
					{
						StatusCode = (int)HttpStatusCode.UnsupportedMediaType
					};

				case NotAuthenticatedResponse notAuthenticatedResponse:
					return new UnauthorizedObjectResult(notAuthenticatedResponse.Message);

				case NotAuthorizedResponse notAuthorizedResponse:
					return new ObjectResult(notAuthorizedResponse.Message)
					{
						StatusCode = (int)HttpStatusCode.Forbidden
					};

				case AggregateResponse aggregateResponse when aggregateResponse.All<SuccessResponse>():
					return new OkObjectResult(aggregateResponse.Message);

				case AggregateResponse aggregateResponse when aggregateResponse.Contains<BadInputResponse>():
					var aggregateModelState = new ModelStateDictionary();
					foreach (var badInputResponse in aggregateResponse.Responses.OfType<BadInputResponse>())
					{
						aggregateModelState.AddModelError(badInputResponse.Resource, badInputResponse.Message);
					}
					return new BadRequestObjectResult(aggregateModelState);

				case AggregateResponse aggregateResponse when aggregateResponse.Contains<ErrorResponse>():
					var builder = new StringBuilder();
					var errors = new List<ErrorEntry>();
					
					foreach (var errorResponse in aggregateResponse.Responses.OfType<ErrorResponse>())
					{
						builder.AppendLine(errorResponse.Message);
						errors.AddRange(errorResponse.Errors);
					}
				
					var aggregateErrorResponse = new ErrorResponse(builder.ToString(), errors);
					
					return new ObjectResult(aggregateErrorResponse)
					{
						StatusCode = (int)HttpStatusCode.InternalServerError,
					};

				case AggregateResponse aggregateResponse when aggregateResponse.Contains<NotFoundResponse>():
					return new NotFoundObjectResult(aggregateResponse.Message);

				case AggregateResponse aggregateResponse when aggregateResponse.Contains<NotSupportedResponse>():
					return new ObjectResult(aggregateResponse.Message)
					{
						StatusCode = (int)HttpStatusCode.UnsupportedMediaType
					};

				case AggregateResponse aggregateResponse when aggregateResponse.Contains<NotAuthenticatedResponse>():
					return new UnauthorizedObjectResult(aggregateResponse.Message);

				case AggregateResponse aggregateResponse when aggregateResponse.Contains<NotAuthorizedResponse>():
					return new ObjectResult(aggregateResponse.Message)
					{
						StatusCode = (int)HttpStatusCode.Forbidden
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

				case SuccessResponse<TData> successResponse when successResponse.Message != null:
					return new OkObjectResult(successResponse.Message);
				
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

				case NotSupportedResponse<TData> notSupportedResponse:
					return new ObjectResult(notSupportedResponse.Message)
					{
						StatusCode = (int)HttpStatusCode.UnsupportedMediaType
					};

				case NotAuthenticatedResponse<TData> notAuthenticatedResponse:
					return new UnauthorizedObjectResult(notAuthenticatedResponse.Message);

				case NotAuthorizedResponse<TData> notAuthorizedResponse:
					return new ObjectResult(notAuthorizedResponse.Message)
					{
						StatusCode = (int)HttpStatusCode.Forbidden
					};
					
				case AggregateResponse<TData> aggregateResponse when aggregateResponse.All<SuccessResponse<TData>>():
					return new OkObjectResult(aggregateResponse.Message);

				case AggregateResponse<TData> aggregateResponse when aggregateResponse.Contains<BadInputResponse<TData>>():
					var aggregateModelState = new ModelStateDictionary();
					foreach (var badInputResponse in aggregateResponse.Responses.OfType<BadInputResponse<TData>>())
					{
						aggregateModelState.AddModelError(badInputResponse.Resource, badInputResponse.Message);
					}
					return new BadRequestObjectResult(aggregateModelState);

				case AggregateResponse<TData> aggregateResponse when aggregateResponse.Contains<ErrorResponse<TData>>():
					var builder = new StringBuilder();
					var errors = new List<ErrorEntry>();

					foreach (var errorResponse in aggregateResponse.Responses.OfType<ErrorResponse<TData>>())
					{
						builder.AppendLine(errorResponse.Message);
						errors.AddRange(errorResponse.Errors);
					}

					var aggregateErrorResponse = new ErrorResponse<TData>(builder.ToString(), errors);

					return new ObjectResult(aggregateErrorResponse)
					{
						StatusCode = (int)HttpStatusCode.InternalServerError,
					};

				case AggregateResponse<TData> aggregateResponse when aggregateResponse.Contains<NotFoundResponse<TData>>():
					return new NotFoundObjectResult(aggregateResponse.Message);

				case AggregateResponse<TData> aggregateResponse when aggregateResponse.Contains<NotSupportedResponse<TData>>():
					return new ObjectResult(aggregateResponse.Message)
					{
						StatusCode = (int)HttpStatusCode.UnsupportedMediaType
					};

				case AggregateResponse<TData> aggregateResponse when aggregateResponse.Contains<NotAuthenticatedResponse<TData>>():
					return new UnauthorizedObjectResult(aggregateResponse.Message);

				case AggregateResponse<TData> aggregateResponse when aggregateResponse.Contains<NotAuthorizedResponse<TData>>():
					return new ObjectResult(aggregateResponse.Message)
					{
						StatusCode = (int)HttpStatusCode.Forbidden
					};
			}

			return new ObjectResult(null)
			{
				StatusCode = (int)HttpStatusCode.InternalServerError
			};
		}
	}
}