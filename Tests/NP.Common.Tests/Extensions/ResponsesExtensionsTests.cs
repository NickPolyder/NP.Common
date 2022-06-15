using NP.Common.Extensions;
using NP.Common.Responses;

namespace NP.Common.Tests.Extensions;

[Trait("Category", "Responses")]
[Trait("Description", "Responses Extensions Tests")]
public class ResponsesExtensionsTests
{
	private readonly IFixture _fixture;

	public ResponsesExtensionsTests()
	{
		_fixture = new Fixture();
	}

	[Fact(DisplayName = "A Response should cast to the generic counterpart with an empty value.")]
	public void A_Response_Should_CastToTData_WithAnEmptyValue()
	{
		// Assign
		var sut = _fixture.Create<SuccessResponse>();

		// Act
		var result = sut.CastTo<int>();
		// Assert
		var successResponse = result.ShouldBeOfType<SuccessResponse<int>>();
		successResponse.Payload.HasValue.ShouldBeFalse();
	}

	[Fact(DisplayName = "A Response should return a new When Builder")]
	public void A_Response_Should_Return_WhenBuilder()
	{
		// Assign
		var sut = _fixture.Create<SuccessResponse>();

		// Act
		var result = sut.When();
		// Assert
		result.ShouldBeOfType<WhenBuilder>();
	}

	[Fact(DisplayName = "A Response should return a new When Builder of T")]
	public void A_Response_Should_Return_WhenBuilderOfT()
	{
		// Assign
		var sut = _fixture.Create<SuccessResponse<int>>();

		// Act
		var result = sut.When();

		// Assert
		result.ShouldBeOfType<WhenBuilder<int>>();
	}
}