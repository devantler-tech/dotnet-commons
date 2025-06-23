using DevantlerTech.Commons.Extensions.StringExtensions;

namespace DevantlerTech.Commons.Extensions.Tests.StringExtensions.GrammarStringExtensionsTests;

/// <summary>
/// Test for <see cref="GrammarStringExtensions.ToPlural"/>.
/// </summary>
public class ToPluralTests
{
  /// <summary>
  /// Test cases for <see cref="GrammarStringExtensions.ToPlural"/>.
  /// </summary>
  /// <param name="input"></param>
  /// <param name="expected"></param>
  [Theory]
  [InlineData(null, null)]
  [InlineData("", "")]
  [InlineData("word", "words")]
  [InlineData("buzz", "buzzes")]
  [InlineData("fox", "foxes")]
  [InlineData("baby", "babies")]
  [InlineData("day", "days")]
  [InlineData("toy", "toys")]
  [InlineData("potato", "potatoes")]
  [InlineData("hero", "heroes")]
  [InlineData("woman", "women")]
  [InlineData("man", "men")]
  [InlineData("child", "children")]
  [InlineData("deer", "deer")]
  [InlineData("species", "species")]
  [InlineData("address", "addresses")]
  [InlineData("addresses", "addresses")]
  public void ToPlural_GivenSingleWord_ReturnsPlural(string? input, string? expected)
  {
    // Act
    string? actual = input?.ToPlural();

    // Assert
    Assert.Equal(expected, actual);
  }
}
