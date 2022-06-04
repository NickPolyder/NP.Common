using NP.Common.Extensions;
using NP.Common.Responses;

namespace NP.Common.Tests.Extensions;

[Trait("Category", "Responses")]
[Trait("Description", "When Extensions Tests")]
public class WhenExtensionsTests
{
	private readonly IFixture _fixture;

	public WhenExtensionsTests()
	{
		_fixture = new Fixture();
	}

	[Fact]
	public void A_Response_Should_Return_WhenBuilder()
	{
		// Assign
		var sut = _fixture.Create<SuccessResponse>();

		// Act
		var result = sut.When();
		// Assert
		result.ShouldBeOfType<WhenBuilder>();
	}

	[Fact]
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