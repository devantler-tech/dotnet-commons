using AutoFixture.Xunit2;
using DevantlerTech.Commons.Extensions.StringExtensions;

namespace DevantlerTech.Commons.Extensions.Tests.StringExtensions.CasingStringExtensionsTests;

/// <summary>
/// Test for <see cref="CasingStringExtensions.ToCamelCase"/>.
/// </summary>
public class ToCamelCaseTests
{
  /// <summary>
  /// Test for <see cref="CasingStringExtensions.ToCamelCase"/>.
  /// </summary>
  [Theory]
  [AutoData]
  [MemberData(nameof(TestCases.CasingTests), MemberType = typeof(TestCases))]
  public void ReturnsCamelCase(string text)
  {
    //Act
    string actual = text.ToCamelCase();

    //Assert
    Assert.Matches(RegexLibrary.CamelCaseWithDigitsRegex(), actual);
  }
}
