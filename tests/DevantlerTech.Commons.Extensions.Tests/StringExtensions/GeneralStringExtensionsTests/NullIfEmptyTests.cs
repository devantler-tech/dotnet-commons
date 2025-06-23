using DevantlerTech.Commons.Extensions.StringExtensions;

namespace DevantlerTech.Commons.Extensions.Tests.StringExtensions.GeneralStringExtensionsTests;

/// <summary>
/// Tests for <see cref="GeneralStringExtensions"/>.
/// </summary>
public class NullIfEmptyTests
{
  /// <summary>
  /// Test that <see cref="GeneralStringExtensions.NullIfEmpty"/> returns null for null and empty strings.
  /// </summary>
  /// <param name="input"></param>
  [Theory]
  [InlineData(null)]
  [InlineData("")]
  public void NullIfEmpty_ReturnsNull_ForNullAndEmptyStrings(string? input)
  {
    // Act
    string? actual = input?.NullIfEmpty();

    // Assert
    Assert.Null(actual);
  }

  /// <summary>
  /// Test that <see cref="GeneralStringExtensions.NullIfEmpty"/> returns the original string for non-empty strings.
  /// </summary>
  /// <param name="input"></param>
  [Theory]
  [InlineData("hello")]
  [InlineData("a")]
  [InlineData(" ")]
  public void NullIfEmpty_ReturnsOriginalString_ForNonEmptyStrings(string input)
  {
    // Act
    string? actual = input.NullIfEmpty();

    // Assert
    Assert.Equal(input, actual);
  }
}
