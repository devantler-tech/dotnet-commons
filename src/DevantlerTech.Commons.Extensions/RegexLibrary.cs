using System.Text.RegularExpressions;

namespace DevantlerTech.Commons.Extensions;

/// <summary>
///     Static class that functions as a library of regular expressions.
/// </summary>
public static partial class RegexLibrary
{
  [GeneratedRegex("-+$")]
  public static partial Regex TrailingDashesRegex();
  [GeneratedRegex(@"([A-ZÆØÅ][a-zæøå]+|[a-zæøå]+|(?<![^\W_])[A-ZÆØÅ]+(?![^\W_])|\B[A-ZÆØÅ]{3,}|[A-ZÆØÅ])")]
  public static partial Regex WordsRegex();
  [GeneratedRegex("^[a-z][a-z0-9]*(([A-Z]{1,3}[a-z0-9]+)*[A-Z]{0,3}|([a-z0-9]+[A-Z]{1,3})*|[A-Z]{1,3})$")]
  public static partial Regex CamelCaseWithDigitsRegex();
  [GeneratedRegex("^[A-Z](([A-Z]{1,2}[a-z0-9]+)+([A-Z]{1,3}[a-z0-9]+)*[A-Z]{0,3}|([a-z0-9]+[A-Z]{0,3})*|[A-Z]{1,2})$")]
  public static partial Regex PascalCaseWithDigitsRegex();
  [GeneratedRegex("^[a-z-]+$")]
  public static partial Regex KebabCaseRegex();
  [GeneratedRegex("_{2,}")]
  public static partial Regex MultipleUnderscoresRegex();
  [GeneratedRegex("-{2,}")]
  public static partial Regex MultipleDashesRegex();
  [GeneratedRegex("([A-Z])([a-z])")]
  public static partial Regex FromUpperCaseChangeRegex();
  [GeneratedRegex("([a-z])([A-Z])")]
  public static partial Regex FromLowerCaseChangeRegex();
  [GeneratedRegex(@"\s+")]
  public static partial Regex WhitespaceRegex();
  [GeneratedRegex("[^a-zA-Z0-9]")]
  public static partial Regex NonAlphanumericRegex();
}
