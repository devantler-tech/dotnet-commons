using System.Globalization;

namespace DevantlerTech.Commons.Extensions.StringExtensions;

/// <summary>
/// Provides extension methods for <see cref="string" /> that help with grammar.
/// </summary>
public static class GrammarStringExtensions
{
  /// <summary>
  /// Converts a word to plural.
  /// </summary>
  /// <param name="word"></param>
  public static string ToPlural(this string word)
  {
    if (string.IsNullOrEmpty(word))
      return word;

    var casing = word[0] == char.ToUpper(word[0], CultureInfo.CurrentCulture)
        ? Casing.Upper
        : Casing.Lower;

    var specialCases = new Dictionary<string, string>
    {
        {"child", "children"},
        {"woman", "women"},
        {"man", "men"},
        {"deer", "deer"}
        // add more as needed
    };

    if (specialCases.TryGetValue(word.ToLower(CultureInfo.CurrentCulture), out string? plural))
    {
      return casing == Casing.Upper
          ? char.ToUpper(plural[0], CultureInfo.CurrentCulture) + plural[1..]
          : plural;
    }
    else if (word.EndsWith("es", StringComparison.OrdinalIgnoreCase))
    {
      return word;
    }
    else if (
        word.EndsWith('x')
        || word.EndsWith('s')
        || word.EndsWith('z')
    )
    {
      return word + "es";
    }
    else if (
        word.EndsWith('y')
        && !word.EndsWith("ay", StringComparison.OrdinalIgnoreCase)
        && !word.EndsWith("ey", StringComparison.OrdinalIgnoreCase)
        && !word.EndsWith("iy", StringComparison.OrdinalIgnoreCase)
        && !word.EndsWith("oy", StringComparison.OrdinalIgnoreCase)
        && !word.EndsWith("uy", StringComparison.OrdinalIgnoreCase)
    )
    {
      int lastIndex = word.Length - 1;
      return word.Remove(lastIndex, 1) + "ies";
    }
    else
    {
      return word.EndsWith('o') ? word + "es" : word + "s";
    }
  }
}
