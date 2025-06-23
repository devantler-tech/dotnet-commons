using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace DevantlerTech.Commons.Extensions;

/// <summary>
/// Extensions for Enum.
/// </summary>
public static class EnumExtensions
{
  /// <summary>
  /// Get the description of an enum.
  /// </summary>
  public static string GetDescriptionOrDefault(this Enum value)
  {
    ArgumentNullException.ThrowIfNull(value, nameof(value));
    var field = value.GetType().GetField(value.ToString());
    var descriptionAttribute = field?.GetCustomAttribute<DescriptionAttribute>();
    return descriptionAttribute?.Description ?? value.ToString();
  }

  /// <summary>
  /// Get the enum member value from an enum.
  /// </summary>
  public static string GetEnumMemberValueOrDefault(this Enum value)
  {
    ArgumentNullException.ThrowIfNull(value, nameof(value));
    var field = value.GetType().GetField(value.ToString());
    var enumMemberAttribute = field?.GetCustomAttribute<EnumMemberAttribute>();
    return enumMemberAttribute?.Value ?? value.ToString();
  }
}
