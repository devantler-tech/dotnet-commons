namespace DevantlerTech.Commons.Extensions.StringExtensions;

/// <summary>
/// General purpose string extensions.
/// </summary>
public static class GeneralStringExtensions
{
  /// <summary>
  /// Returns null if the string is null or empty.
  /// </summary>
  /// <param name="text"></param>
  public static string? NullIfEmpty(this string text)
      => string.IsNullOrEmpty(text) ? null : text;
}
