using System.ComponentModel.DataAnnotations;
using AutoFixture.Xunit2;
using DevantlerTech.Commons.Extensions.StringExtensions;

namespace DevantlerTech.Commons.Extensions.Tests.StringExtensions.FormattingStringExtensionsTests;

/// <summary>
/// Test cases for <see cref="FormattingStringExtensions"/>.
/// </summary>
public class IndentTests
{
  /// <summary>
  /// Given a single line text and a positive indent size, indents the text by the specified spaces.
  /// </summary>
  /// <param name="text"></param>
  /// <param name="indentSize"></param>
  [Theory]
  [AutoData]
  public void GivenSingleLineTextAndPositiveIndentSize_IndentsBySpecifiedSpaces(string text, int indentSize)
  {
    //Act
    string actual = text.Indent(indentSize);

    //Assert
    Assert.StartsWith(new string(' ', indentSize), actual, StringComparison.Ordinal);
  }

  /// <summary>
  /// Given multi-line text with ignore first line set to true, ignores the first line.
  /// </summary>
  [Fact]
  public void GivenMultiLineTextAndIgnoreFirstLine_IgnoresFirstLine()
  {
    //Arrange
    const string MultiLineText = """
        first line
        second line
        """;

    //Act
    string actual = MultiLineText.Indent(4, true);

    //Assert
    Assert.StartsWith("first line", actual, StringComparison.Ordinal);
    Assert.EndsWith("    second line", actual, StringComparison.Ordinal);
  }

  /// <summary>
  /// Given multi-line text and a positive indent size, indents the text by the specified spaces.
  /// </summary>
  /// <param name="multiLineText"></param>
  /// <param name="indentSize"></param>
  [Theory]
  [InlineAutoData(
      """
        first line
        second line
        """
  )]
  public void GivenMultiLineTextAndPositiveIndentSize_IndentsBySpecifiedSpaces(string multiLineText, int indentSize)
  {
    //Act
    string actual = multiLineText.Indent(indentSize);

    //Assert
    Assert.All(actual.Split(Environment.NewLine), line => Assert.StartsWith(new string(' ', indentSize), line, StringComparison.Ordinal));
  }

  /// <summary>
  /// Given a single line text and a negative indent size, throws an <see cref="ArgumentOutOfRangeException"/>.
  /// </summary>
  /// <param name="indentSize"></param>
  [Theory]
  [AutoData]
  public void GivenSingleLineTextAndNegativeIndentSize_Throws([Range(-100, -1)] int indentSize)
  {
    //Act
    void action() => "this is a test".Indent(indentSize);

    //Assert
    _ = Assert.Throws<ArgumentOutOfRangeException>(action);
  }
}
