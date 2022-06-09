using NP.Common.Extensions;

namespace NP.Common.Tests.Extensions;

[Trait("Category", "Extensions")]
[Trait("Description", "Collection Extensions Tests")]
public class CollectionExtensionsTests
{
	private readonly IFixture _fixture;

	public CollectionExtensionsTests()
	{
		_fixture = new Fixture();
	}

	[Fact(DisplayName = "AddIf should throw Argument Null Exception when the collection is null")]
	public void AddIf_ShouldThrowException_WhenCollectionIsNull()
	{
		// Assign
		List<int>? sut = null;

		// Act
		var result = Record.Exception(() => sut.AddIf(x => true, 1));

		// Assert
		result.ShouldBeOfType<ArgumentNullException>()
			.ParamName.ShouldBe("collection");
	}

	[Fact(DisplayName = "AddIf should throw Argument Null Exception when the predicate is null")]
	public void AddIf_ShouldThrowException_WhenPredicateIsNull()
	{
		// Assign
		var sut = new List<int>();

		// Act
		var result = Record.Exception(() => sut.AddIf(null, 1));

		// Assert
		result.ShouldBeOfType<ArgumentNullException>()
			.ParamName.ShouldBe("predicate");
	}

	[Fact(DisplayName = "AddIf should add the entry when the predicate returns true.")]
	public void AddIf_ShouldAddEntry_WhenPredicateIsMet()
	{
		// Assign
		var sut = new List<int>();
		var expectedValue = _fixture.Create<int>();

		// Act
		 sut.AddIf(x => true, expectedValue);

		// Assert
		sut.Count.ShouldBe(1);
		sut[0].ShouldBe(expectedValue);
	}

	[Fact(DisplayName = "AddIf should not add the entry when the predicate returns false.")]
	public void AddIf_ShouldNotAddEntry_WhenPredicateIsNotMet()
	{
		// Assign
		var sut = new List<int>();
		var expectedValue = _fixture.Create<int>();

		// Act
		sut.AddIf(x => false, expectedValue);

		// Assert
		sut.Count.ShouldBe(0);
	}
}