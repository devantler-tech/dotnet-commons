using AutoFixture.Xunit2;
using DevantlerTech.Commons.Extensions.StringExtensions;

namespace DevantlerTech.Commons.Extensions.Tests.StringExtensions.CasingStringExtensionsTests;

/// <summary>
/// Test for <see cref="CasingStringExtensions.ToPascalCase"/>.
/// </summary>
public class ToPascalCaseTests
{
  /// <summary>
  /// Tests that the method returns a string in Pascal case.
  /// </summary>
  /// <param name="text"></param>
  [Theory, AutoData]
  [MemberData(nameof(TestCases.CasingTests), MemberType = typeof(TestCases))]
  public void ReturnsToPascalCase(string text)
  {
    //Act
    string actual = text.ToPascalCase();

    //Assert
    Assert.Matches(RegexLibrary.PascalCaseWithDigitsRegex(), actual);
  }
}
