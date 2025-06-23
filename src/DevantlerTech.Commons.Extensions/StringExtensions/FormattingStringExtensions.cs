using System.Text;

namespace DevantlerTech.Commons.Extensions.StringExtensions;

/// <summary>
/// Provides extension methods for <see cref="string" /> that help with formatting strings.
/// </summary>
public static class FormattingStringExtensions
{
  /// <summary>
  ///     Indents a string by the specified number of spaces. Or four spaces if no argument is provided.
  /// </summary>
  /// <param name="text"></param>
  /// <param name="spaces"></param>
  /// <param name="ignoreFirstLine"></param>
  public static string Indent(this string text, int spaces = 4, bool ignoreFirstLine = false)
  {
    ArgumentException.ThrowIfNullOrEmpty(text, nameof(text));
    StringBuilder builder = new();
    string[] lines = text.Split(Environment.NewLine.ToCharArray());
    for (int i = 0; i < text.Split(Environment.NewLine.ToCharArray()).Length; i++)
    {
      if (i == 0 && ignoreFirstLine)
      {
        _ = builder.AppendLine(lines[i]);
        continue;
      }

      _ = i < lines.Length - 1
          ? builder.Append(new string(' ', spaces)).AppendLine(lines[i])
          : builder.Append(new string(' ', spaces)).Append(lines[i]);
    }

    return builder.ToString();
  }
}
