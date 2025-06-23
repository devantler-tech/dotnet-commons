using DevantlerTech.Commons.Extensions.StringExtensions;

namespace DevantlerTech.Commons.Extensions.Tests.StringExtensions.CasingStringExtensionsTests;

/// <summary>
/// Test cases for <see cref="CasingStringExtensions"/>.
/// </summary>
static class TestCases
{
  /// <summary>
  /// Casing tests.
  /// </summary>
  public static TheoryData<string> CasingTests =>
    [
      "kebab-case",
      "camelCase",
      "UPPER_SNAKE_CASE",
      "lower_snake_case",
      "lower-train-case",
      "UPPER-TRAIN-CASE",
      "PascalCase",
      "PascalCaseWithDigits123",
      "Title Case"
    ];
}
