using NP.Common.Extensions;
using NP.Common.Responses;

namespace NP.Common.Tests.Extensions;

[Trait("Category", "Extensions")]
[Trait("Description", "Object Extensions Tests")]
public class ObjectExtensionsTests
{
	private readonly IFixture _fixture;

	public ObjectExtensionsTests()
	{
		_fixture = new Fixture();
	}

	[Fact(DisplayName = "As should return the casted type when it is able")]
	public void As_ShouldReturnCast_WhenItIsOfType()
	{
		// Assign
		var message = _fixture.Create<string>();
		var data = Maybe<int>.WithValue(_fixture.Create<int>());
		var sut = new SuccessResponse<int>(message, data);

		// Act
		var result = sut.As<SuccessResponse>();

		// Assert
		(result is SuccessResponse).ShouldBeTrue();
	}

	[Fact(DisplayName = "As should return the default when it cannot cast")]
	public void As_ShouldReturnDefault_WhenItCannotCast()
	{
		// Assign
		var message = _fixture.Create<string>();
		var data = Maybe<int>.WithValue(_fixture.Create<int>());
		var sut = new SuccessResponse<int>(message, data);

		// Act
		var result = sut.As<BadInputResponse>();

		// Assert
		result.ShouldBeNull();
	}

	[Fact(DisplayName = "IsNull should return true when the object is null")]
	public void IsNull_ShouldReturnTrue_WhenObjectIsNull()
	{
		// Assign
		object? sut = null;

		// Act
		var result = sut.IsNull();

		// Assert
		result.ShouldBeTrue();
	}


	[Fact(DisplayName = "IsNull should return false when the object is not null")]
	public void IsNull_ShouldReturnFalse_WhenObjectIsNotNull()
	{
		// Assign
		var sut = _fixture.Create<object>();

		// Act
		var result = sut.IsNull();

		// Assert
		result.ShouldBeFalse();
	}
}