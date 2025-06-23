namespace DevantlerTech.Commons.Extensions.Tests.EnumExtensionsTests;

/// <summary>
/// Tests for <see cref="EnumExtensions.GetDescriptionOrDefault(Enum)"/>.
/// </summary>
public partial class GetDescriptionOrDefaultTests
{
  /// <summary>
  /// Tests that the description of an enum is returned when the enum has a description attribute.
  /// </summary>
  [Fact]
  public void GetDescriptionOrDefault_WithDescriptionAttribute_ReturnsDescription()
  {
    // Arrange
    var enumValue = TestEnum.FirstValue;

    // Act
    string description = enumValue.GetDescriptionOrDefault();

    // Assert
    Assert.Equal("First Value - Description", description);
  }

  /// <summary>
  /// Tests that the name of an enum is returned when the enum does not have a description attribute.
  /// </summary>
  [Fact]
  public void GetDescriptionOrDefault_WithoutDescriptionAttribute_ReturnsEnumName()
  {
    // Arrange
    var enumValue = TestEnum.SecondValue;

    // Act
    string description = enumValue.GetDescriptionOrDefault();

    // Assert
    Assert.Equal("SecondValue", description);
  }
}
