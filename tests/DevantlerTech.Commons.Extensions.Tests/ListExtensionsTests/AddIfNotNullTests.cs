namespace DevantlerTech.Commons.Extensions.Tests.ListExtensionsTests;

/// <summary>
/// Test for <see cref="ListExtensions.AddIfNotNull"/>.
/// </summary>
public class AddIfNotNullTests
{
  /// <summary>
  /// Tests that the method adds a formatted string to the list if all values are not null.
  /// </summary>
  [Fact]
  public void AddIfNotNull_AllValuesNotNull_AddsFormattedString()
  {
    // Arrange
    var list = new List<string>();
    string format = "Hello, {0} {1}!";
    object?[] values = ["John", "Doe"];

    // Act
    list.AddIfNotNull(format, values);

    // Assert
    _ = Assert.Single(list);
    Assert.Equal("Hello, John Doe!", list[0]);
  }

  /// <summary>
  /// Tests that the method does not add a formatted string to the list if one of the values is null.
  /// </summary>
  [Fact]
  public void AddIfNotNull_ContainsNullValue_DoesNotAddString()
  {
    // Arrange
    var list = new List<string>();
    string format = "Hello, {0} {1}!";
    object?[] values = ["John", null];

    // Act
    list.AddIfNotNull(format, values);

    // Assert
    Assert.Empty(list);
  }

  /// <summary>
  /// Tests that the method throws a <see cref="FormatException"/> if the number of values does not match the format.
  /// </summary>
  [Fact]
  public void AddIfNotNull_InvalidNumberOfValues_ThrowsFormatException()
  {
    // Arrange
    var list = new List<string>();
    string format = "Hello, {0} {1}!";
    object?[] values = [];

    // Act
    void act() => list.AddIfNotNull(format, values);

    // Assert
    _ = Assert.Throws<FormatException>(act);
  }

  /// <summary>
  /// Tests that the method throws a <see cref="FormatException"/> if the format is invalid.
  /// </summary>
  [Fact]
  public void AddIfNotNull_InvalidFormat_ThrowsFormatException()
  {
    // Arrange
    var list = new List<string>();
    string format = "Hello, {0} {1!";
    object?[] values = ["John", "Doe"];

    // Act
    void act() => list.AddIfNotNull(format, values);

    // Assert
    _ = Assert.Throws<FormatException>(act);
  }
}
