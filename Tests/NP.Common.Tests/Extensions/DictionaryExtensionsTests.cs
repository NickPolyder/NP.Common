using NP.Common.Extensions;

namespace NP.Common.Tests.Extensions;

[Trait("Category", "Extensions")]
[Trait("Description", "Dictionary Extensions Tests")]

public class DictionaryExtensionsTests
{
	private readonly IFixture _fixture;

	public DictionaryExtensionsTests()
	{
		_fixture = new Fixture();
	}

	[Fact(DisplayName = "GetOrAdd should throw Argument Null Exception when the dictionary is null")]
	public void GetOrAdd_ShouldThrowException_WhenCollectionIsNull()
	{
		// Assign
		Dictionary<int, int>? sut = null;

		// Act
		var result = Record.Exception(() => sut.GetOrAdd(1,key => 0));

		// Assert
		result.ShouldBeOfType<ArgumentNullException>()
			.ParamName.ShouldBe("dictionary");
	}

	[Fact(DisplayName = "GetOrAdd should throw Argument Null Exception when the factory is null")]
	public void GetOrAdd_ShouldThrowException_WhenFactoryIsNull()
	{
		// Assign
		var sut = new Dictionary<int, int>();

		// Act
		var result = Record.Exception(() => sut.GetOrAdd(1, null));

		// Assert
		result.ShouldBeOfType<ArgumentNullException>()
			.ParamName.ShouldBe("factory");
	}

	[Fact(DisplayName = "GetOrAdd should get the entry when the entry exists")]
	public void GetOrAdd_ShouldGetEntry_WhenTheEntryExists()
	{
		// Assign
		var sut = new Dictionary<int, int>();
		var expectedKey = _fixture.Create<int>();
		var expectedValue = _fixture.Create<int>();
		var factoryValue = _fixture.Create<int>();
		sut.Add(expectedKey, expectedValue);
		// Act
		var result = sut.GetOrAdd(expectedKey, key => factoryValue);

		// Assert
		sut.Count.ShouldBe(1);
		sut[expectedKey].ShouldBe(expectedValue);
	}

	[Fact(DisplayName = "GetOrAdd should add and return entry when the entry does not exist.")]
	public void GetOrAdd_ShouldAddAndReturnEntry_WhenTheEntryDoesNotExist()
	{
		// Assign
		var sut = new Dictionary<int, int>();
		var expectedKey = _fixture.Create<int>();
		var factoryValue = _fixture.Create<int>();
		int? actualKey = null;
		
		// Act
		var result = sut.GetOrAdd(expectedKey, key =>
		{
			actualKey = key;
			return factoryValue;
		});

		// Assert
		actualKey.ShouldBe(expectedKey);
		result.ShouldBe(factoryValue);
		sut.Count.ShouldBe(1);
		sut[expectedKey].ShouldBe(factoryValue);
	}
}