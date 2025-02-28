namespace Devantler.Commons.Extensions.Tests.EnumExtensionsTests;

/// <summary>
/// Tests for <see cref="EnumExtensions.GetEnumMemberValueOrDefault(Enum)"/>.
/// </summary>
public class GetEnumMemberValueOrDefaultTests
{
  /// <summary>
  /// Tests that the enum member value is returned when the enum has an enum member attribute.
  /// </summary>
  [Fact]
  public void GetEnumMemberValueOrDefault_WithEnumMemberAttribute_ReturnsEnumMemberValue()
  {
    // Arrange
    var enumValue = TestEnum.FirstValue;

    // Act
    string enumMemberValue = enumValue.GetEnumMemberValueOrDefault();

    // Assert
    Assert.Equal("First Value - Enum Member", enumMemberValue);
  }

  /// <summary>
  /// Tests that the name of an enum is returned when the enum does not have an enum member attribute.
  /// </summary>
  [Fact]
  public void GetEnumMemberValueOrDefault_WithoutEnumMemberAttribute_ReturnsEnumName()
  {
    // Arrange
    var enumValue = TestEnum.SecondValue;

    // Act
    string enumMemberValue = enumValue.GetEnumMemberValueOrDefault();

    // Assert
    Assert.Equal("SecondValue", enumMemberValue);
  }
}
