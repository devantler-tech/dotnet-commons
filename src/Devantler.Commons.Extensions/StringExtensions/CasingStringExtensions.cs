using System.Text;

namespace Devantler.Commons.Extensions.StringExtensions;

/// <summary>
/// A class with extension methods for <see cref="string"/> that can convert strings to different casing styles.
/// </summary>
public static class CasingStringExtensions
{
  /// <summary>
  ///     Converts a string to PascalCase.
  /// </summary>
  /// <param name="text"></param>
  public static string ToPascalCase(this string text)
  {
    if (RegexLibrary.PascalCaseWithDigitsRegex().IsMatch(text))
      return text;
    if (RegexLibrary.CamelCaseWithDigitsRegex().IsMatch(text))
      return text[..1].ToUpper(System.Globalization.CultureInfo.CurrentCulture) + text[1..];

    text = RegexLibrary.WordsRegex()
        .Replace(text, m => m.Value[..1].ToUpper(System.Globalization.CultureInfo.CurrentCulture) + m.Value[1..].ToLower(System.Globalization.CultureInfo.CurrentCulture));

    text = RegexLibrary.NonAlphanumericRegex().Replace(text, string.Empty);

    text = RegexLibrary.WhitespaceRegex().Replace(text, string.Empty);

    return text;
  }

  /// <summary>
  ///     Converts a string to camelCase.
  /// </summary>
  /// <param name="text"></param>
  public static string ToCamelCase(this string text)
  {
    if (RegexLibrary.CamelCaseWithDigitsRegex().IsMatch(text))
      return text;

    text = text.ToPascalCase();

    return text[..1].ToLower(System.Globalization.CultureInfo.CurrentCulture) + text[1..];
  }

  /// <summary>
  ///     Converts a string to kebab-case.
  /// </summary>
  /// <param name="text"></param>
  public static string ToKebabCase(this string text)
  {
    if (RegexLibrary.KebabCaseRegex().IsMatch(text))
      return text;

    text = text.ToPascalCase();

    return RegexLibrary.WordsRegex().Matches(text)
        .Select(m => m.Value)
        .Aggregate(new StringBuilder(), (sb, s) => sb.Append(s.ToLower(System.Globalization.CultureInfo.CurrentCulture)).Append('-'))
        .ToString()[..^1];
  }
}
