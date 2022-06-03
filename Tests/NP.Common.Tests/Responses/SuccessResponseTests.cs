using NP.Common.Responses;

namespace NP.Common.Tests.Responses;

[Trait("Description", "Success Response Tests")]
public class SuccessResponseTests
{
	[Fact]
	public void SuccessResponse()
	{
		var result = Record.Exception(() => new SuccessResponse());

		result.ShouldBeNull();
	}
}