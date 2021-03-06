using NP.Common.Extensions;
using NP.Common.Responses;

namespace NP.Common.Tests.Responses;

[Trait("Category", "Responses")]
[Trait("Description", "When Builder Tests")]
public class WhenBuilderTests
{
	private readonly IFixture _fixture;

	public WhenBuilderTests()
	{
		_fixture = new Fixture();
	}

	[Fact(DisplayName = "Execute should run the action and store the response.")]
	public void Execute_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.Execute(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse;
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		sut.Return().ShouldBe(changedResponse);
	}

	[Fact(DisplayName = "Execute Async should run the action and store the response.")]
	public async Task ExecuteAsync_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteAsync((request, token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse>(changedResponse);
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		sut.Return().ShouldBe(changedResponse);

	}

	[Fact(DisplayName = "Execute<TData> should run the action and store the response of TData.")]
	public void ExecuteOfTData_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.Execute<int>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse.CastTo<int>(Maybe<int>.Empty);
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		var returned = sut.Return();
		returned.ShouldBeOfType<BadInputResponse<int>>().Payload.ShouldBe(Maybe<int>.Empty);
		returned.Message.ShouldBe(changedResponse.Message);
	}

	[Fact(DisplayName = "ExecuteAsync<TData> should run the action and store the response of TData.")]
	public async Task ExecuteAsyncOfTData_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteAsync<int>((request, token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse<int>>(changedResponse.CastTo<int>(Maybe<int>.Empty));
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		var returned = sut.Return();
		returned.ShouldBeOfType<BadInputResponse<int>>().Payload.ShouldBe(Maybe<int>.Empty);
		returned.Message.ShouldBe(changedResponse.Message);
	}

	[Fact(DisplayName = "ExecuteIf with the correct concrete type should run the action and save the response.")]
	public void ExecuteIf_WhenTheConcreteMatches_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.ExecuteIf<SuccessResponse>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse;
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		sut.Return().ShouldBe(changedResponse);
	}

	[Fact(DisplayName = "ExecuteIf with the incorrect concrete type should NOT run the action.")]
	public void ExecuteIf_WhenTheConcreteDoesNotMatch_ShouldNotRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.ExecuteIf<ErrorResponse>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse;
		});

		// Assert
		hasBeenCalled.ShouldBeFalse();
		actualResponse.ShouldBeNull();
		sut.Return().ShouldBe(request);
	}

	[Fact(DisplayName = "ExecuteIfAsync with the correct concrete type should run the action and save the response.")]
	public async Task ExecuteIfAsync_WhenTheConcreteMatches_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteIfAsync<SuccessResponse>((request, token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse>(changedResponse);
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		sut.Return().ShouldBe(changedResponse);
	}

	[Fact(DisplayName = "ExecuteIfAsync with the incorrect concrete type should NOT run the action.")]
	public async Task ExecuteIfAsync_WhenTheConcreteDoesNotMatch_ShouldNotRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteIfAsync<ErrorResponse>((request, token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse>(changedResponse);
		});

		// Assert
		hasBeenCalled.ShouldBeFalse();
		actualResponse.ShouldBeNull();
		sut.Return().ShouldBe(request);
	}


	[Fact(DisplayName = "ExecuteIf of TData with the correct concrete type should run the action and save the response.")]
	public void ExecuteIfOfTData_WhenTheConcreteMatches_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.ExecuteIf<SuccessResponse, int>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse.CastTo<int>(Maybe<int>.Empty);
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		var returned = sut.Return();
		returned.ShouldBeOfType<BadInputResponse<int>>().Payload.ShouldBe(Maybe<int>.Empty);
		returned.Message.ShouldBe(changedResponse.Message);
	}

	[Fact(DisplayName = "ExecuteIf of TData with the incorrect concrete type should NOT run the action.")]
	public void ExecuteIfOfTData_WhenTheConcreteDoesNotMatch_ShouldNotRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.ExecuteIf<ErrorResponse, int>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse.CastTo<int>(Maybe<int>.Empty);
		});

		// Assert
		hasBeenCalled.ShouldBeFalse();
		actualResponse.ShouldBeNull();
		sut.Return().ShouldBe(request);
	}

	[Fact(DisplayName = "ExecuteIfAsync of TData with the correct concrete type should run the action and save the response.")]
	public async Task ExecuteIfAsyncOfTData_WhenTheConcreteMatches_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteIfAsync<SuccessResponse, int>((request, token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse<int>>(changedResponse.CastTo<int>(Maybe<int>.Empty));
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		var returned = sut.Return();
		returned.ShouldBeOfType<BadInputResponse<int>>().Payload.ShouldBe(Maybe<int>.Empty);
		returned.Message.ShouldBe(changedResponse.Message);
	}

	[Fact(DisplayName = "ExecuteIfAsync of TData with the incorrect concrete type should NOT run the action.")]
	public async Task ExecuteIfAsyncOfTData_WhenTheConcreteDoesNotMatch_ShouldNotRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteIfAsync<ErrorResponse, int>((request, token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse<int>>(changedResponse.CastTo<int>(Maybe<int>.Empty));
		});

		// Assert
		hasBeenCalled.ShouldBeFalse();
		actualResponse.ShouldBeNull();
		sut.Return().ShouldBe(request);
	}

	[Fact(DisplayName = "ExecuteIfNot with the correct concrete type should NOT run the action and save the response.")]
	public void ExecuteIfNot_WhenTheConcreteMatches_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.ExecuteIfNot<SuccessResponse>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse;
		});

		// Assert
		hasBeenCalled.ShouldBeFalse();
		actualResponse.ShouldBeNull();
		sut.Return().ShouldBe(request);
	}

	[Fact(DisplayName = "ExecuteIfNot with the incorrect concrete type should run the action.")]
	public void ExecuteIfNot_WhenTheConcreteDoesNotMatch_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.ExecuteIfNot<ErrorResponse>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse;
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		sut.Return().ShouldBe(changedResponse);
	}




	[Fact(DisplayName = "ExecuteIfNotAsync with the correct concrete type should NOT run the action and save the response.")]
	public async Task ExecuteIfNotAsync_WhenTheConcreteMatches_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteIfNotAsync<SuccessResponse>((request , token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse>(changedResponse);
		});

		// Assert
		hasBeenCalled.ShouldBeFalse();
		actualResponse.ShouldBeNull();
		sut.Return().ShouldBe(request);
	}

	[Fact(DisplayName = "ExecuteIfNotAsync with the incorrect concrete type should run the action.")]
	public async Task ExecuteIfNotAsync_WhenTheConcreteDoesNotMatch_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteIfNotAsync<ErrorResponse>((request , token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse>(changedResponse);
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		sut.Return().ShouldBe(changedResponse);
	}
	
	[Fact(DisplayName = "ExecuteIfNot Of TData with the correct concrete type should NOT run the action and save the response.")]
	public void ExecuteIfNot_OfTData_WhenTheConcreteMatches_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.ExecuteIfNot<SuccessResponse, int>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse.CastTo<int>(Maybe<int>.Empty);
		});

		// Assert
		hasBeenCalled.ShouldBeFalse();
		actualResponse.ShouldBeNull();
		sut.Return().ShouldBe(request);
	}

	[Fact(DisplayName = "ExecuteIfNot Of TData with the incorrect concrete type should run the action.")]
	public void ExecuteIfNot_OfTData_WhenTheConcreteDoesNotMatch_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		sut.ExecuteIfNot<ErrorResponse, int>(request =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return changedResponse.CastTo<int>(Maybe<int>.Empty);
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		var returned = sut.Return();
		returned.ShouldBeOfType<BadInputResponse<int>>().Payload.ShouldBe(Maybe<int>.Empty);
		returned.Message.ShouldBe(changedResponse.Message);
	}




	[Fact(DisplayName = "ExecuteIfNotAsync Of TData with the correct concrete type should NOT run the action and save the response.")]
	public async Task ExecuteIfNotAsync_OfTData_WhenTheConcreteMatches_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteIfNotAsync<SuccessResponse, int>((request, token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse<int>>(changedResponse.CastTo<int>(Maybe<int>.Empty));
		});

		// Assert
		hasBeenCalled.ShouldBeFalse();
		actualResponse.ShouldBeNull();
		sut.Return().ShouldBe(request);
	}

	[Fact(DisplayName = "ExecuteIfNotAsync Of TData with the incorrect concrete type should run the action.")]
	public async Task ExecuteIfNotAsync_OfTData_WhenTheConcreteDoesNotMatch_ShouldRunAndStoreTheResponse()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		IResponse? actualResponse = null;

		// Act
		await sut.ExecuteIfNotAsync<ErrorResponse, int>((request, token) =>
		{
			actualResponse = request;
			hasBeenCalled = true;
			return Task.FromResult<IResponse<int>>(changedResponse.CastTo<int>(Maybe<int>.Empty));
		});

		// Assert
		hasBeenCalled.ShouldBeTrue();
		actualResponse.ShouldNotBeNull().ShouldBe(request);
		var returned = sut.Return();
		returned.ShouldBeOfType<BadInputResponse<int>>().Payload.ShouldBe(Maybe<int>.Empty);
		returned.Message.ShouldBe(changedResponse.Message);
	}

	[Fact(DisplayName = "Return should return the request object when the response is not set.")]
	public void Return_ShouldReturnRequest_WhenTheResponseIsNotSet()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();

		// Act
		var result = sut.Return();

		// Assert
		result.ShouldBe(request);
	}

	[Fact(DisplayName = "Return should return the Response object when the response is set.")]
	public void Return_ShouldReturnResponse_WhenTheResponseIsSet()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse>();
		sut.Execute(request =>
		{
			hasBeenCalled = true;
			return changedResponse;
		});

		// Act
		var result = sut.Return();

		// Assert
		hasBeenCalled.ShouldBeTrue();
		result.ShouldBe(changedResponse);
	}

	[Fact(DisplayName = "Return of T, should return the casted Response object when the response is already of type IResponse<T>.")]
	public void ReturnOfT_ShouldReturnTheCastedResponse_WhenTheResponseIsAlreadyCasted()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse<int>>();
		sut.Execute(request =>
		{
			hasBeenCalled = true;
			return changedResponse;
		});

		// Act
		var result = sut.Return<int>();

		// Assert
		hasBeenCalled.ShouldBeTrue();
		result.ShouldBeOfType<BadInputResponse<int>>();
		result.ShouldBe(changedResponse);
	}

	[Fact(DisplayName = "Return of T, should return an Empty Payload when the response is not already of type IResponse<T>")]
	public void ReturnOfT_ShouldReturnAnEmptyPayload()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		
		// Act
		var result = sut.Return<int>();

		// Assert
		var successResult = result.ShouldBeOfType<SuccessResponse<int>>();
		successResult.Payload.HasValue.ShouldBeFalse();
	}

	[Fact(DisplayName = "Return of T, should return an Empty Payload when the response is not already of type IResponse<T>")]
	public void ReturnOfT_ShouldCastToTheNewResponseOfT()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();

		// Act
		var result = sut.Return<int>();

		// Assert
		var successResult = result.ShouldBeOfType<SuccessResponse<int>>();
		successResult.Payload.HasValue.ShouldBeFalse();
		successResult.Message.ShouldBe(request.Message);
	}
	

	[Fact(DisplayName = "Return of T with data, should cast the Response object with the new value")]
	public void ReturnOfTWithData_ShouldCastResponseWithNewData()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var hasBeenCalled = false;
		var changedResponse = _fixture.Create<BadInputResponse<int>>();
		sut.Execute(request =>
		{
			hasBeenCalled = true;
			return changedResponse;
		});

		var expectedData = _fixture.Create<int>();

		// Act
		var result = sut.Return<int>(Maybe<int>.WithValue(expectedData));

		// Assert
		hasBeenCalled.ShouldBeTrue();
		var badInputResult = result.ShouldBeOfType<BadInputResponse<int>>();
		badInputResult.Payload.HasValue.ShouldBeTrue();
		badInputResult.Payload.Value.ShouldBe(expectedData);
	}
	
	[Fact(DisplayName = "Return of T with data, should return the new IResponse<T> with the Data in")]
	public void ReturnOfTWithData_ShouldCastToTheNewResponseOfT()
	{
		// Assign
		var request = _fixture.Create<SuccessResponse>();
		var sut = request.When();
		var expectedData = _fixture.Create<int>();

		// Act
		var result = sut.Return<int>(Maybe<int>.WithValue(expectedData));

		// Assert
		var successResult = result.ShouldBeOfType<SuccessResponse<int>>();
		successResult.Payload.HasValue.ShouldBeTrue();
		successResult.Payload.Value.ShouldBe(expectedData);
		successResult.Message.ShouldBe(request.Message);
	}

	[Fact(DisplayName = "Return of T with data, should return null when the result is null.")]
	public void ReturnOfTWithData_ShouldReturnNull_WhenTheResultIsNull()
	{
		// Assign
		SuccessResponse? request = null;
		var sut = request.When();
		var expectedData = _fixture.Create<int>();

		// Act
		var result = sut.Return<int>(Maybe<int>.WithValue(expectedData));

		// Assert
		result.ShouldBeNull();
	}
}