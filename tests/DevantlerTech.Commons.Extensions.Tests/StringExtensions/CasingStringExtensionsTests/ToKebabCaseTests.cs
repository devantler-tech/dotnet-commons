using AutoFixture.Xunit2;
using DevantlerTech.Commons.Extensions.StringExtensions;

namespace DevantlerTech.Commons.Extensions.Tests.StringExtensions.CasingStringExtensionsTests;

/// <summary>
/// Test for <see cref="CasingStringExtensions.ToKebabCase"/>.
/// </summary>
public class ToKebabCaseTests
{
  /// <summary>
  /// Tests that the method returns a string in kebab case.
  /// </summary>
  /// <param name="text"></param>
  [Theory]
  [AutoData]
  [MemberData(nameof(TestCases.CasingTests), MemberType = typeof(TestCases))]
  public void ReturnsKebabCase(string text)
  {
    //Act
    string actual = text.ToKebabCase();

    //Assert
    Assert.Matches(RegexLibrary.KebabCaseRegex(), actual);
  }
}
