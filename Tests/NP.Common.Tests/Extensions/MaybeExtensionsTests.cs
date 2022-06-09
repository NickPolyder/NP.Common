using NP.Common.Extensions;

namespace NP.Common.Tests.Extensions;

[Trait("Category", "Extensions")]
[Trait("Description", "Maybe Extensions Tests")]
public class MaybeExtensionsTests
{
	private readonly IFixture _fixture;

	public MaybeExtensionsTests()
	{
		_fixture = new Fixture();
	}

	[Fact(DisplayName = "AsMaybe should return an empty value when the value is null")]
	public void AsMaybe_ShouldReturnEmpty_WhenValueIsNull()
	{
		// Assign
		string? sut = null;

		// Act
		var result = sut.AsMaybe();

		// Assert
		result.ShouldBe(Maybe<string?>.Empty);
	}

	[Fact(DisplayName = "AsMaybe should return a Maybe value when the value is not null")]
	public void AsMaybe_ShouldReturnValue_WhenValueIsNotNull()
	{
		// Assign
		var sut = _fixture.Create<string>();

		// Act
		var result = sut.AsMaybe();

		// Assert
		result.HasValue.ShouldBeTrue();
		result.Value.ShouldBe(sut);
	}
}