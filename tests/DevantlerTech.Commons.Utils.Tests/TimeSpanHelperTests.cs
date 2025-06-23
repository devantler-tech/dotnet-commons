namespace DevantlerTech.Commons.Utils.Tests;

/// <summary>
/// Tests for <see cref="TimeSpanHelper"/>.
/// </summary>
public class TimeSpanHelperTests
{
  /// <summary>
  /// Test cases for <see cref="TimeSpanHelper.ParseDuration"/>.
  /// </summary>
  /// <param name="format"></param>
  /// <param name="days"></param>
  /// <param name="hours"></param>
  /// <param name="minutes"></param>
  /// <param name="seconds"></param>
  /// <param name="ticks"></param>
  [Theory]
  [InlineData("1y", 365, 0, 0, 0, 0)]
  [InlineData("1M", 30, 0, 0, 0, 0)]
  [InlineData("1w", 7, 0, 0, 0, 0)]
  [InlineData("1d", 1, 0, 0, 0, 0)]
  [InlineData("1h", 0, 1, 0, 0, 0)]
  [InlineData("1m", 0, 0, 1, 0, 0)]
  [InlineData("1s", 0, 0, 0, 1, 0)]
  [InlineData("1t", 0, 0, 0, 0, 1)]
  [InlineData("1y1M1w1d1h1m1s1t", 365 + 30 + 7 + 1, 1, 1, 1, 1)]
  public void ParseDuration_ValidFormat_ReturnsExpectedTimeSpan(string format, int days, int hours, int minutes, int seconds, long ticks)
  {
    // Act
    var result = TimeSpanHelper.ParseDuration(format);

    // Assert
    var expected = new TimeSpan(days, hours, minutes, seconds, 0).Add(TimeSpan.FromTicks(ticks));
    Assert.Equal(expected, result);
  }

  /// <summary>
  /// Test cases for <see cref="TimeSpanHelper.ParseDuration"/>.
  /// </summary>
  /// <param name="format"></param>
  [Theory]
  [InlineData("")]
  [InlineData("1x")]
  public void ParseDuration_InvalidFormat_ThrowsException(string format) =>
    Assert.ThrowsAny<Exception>(() => TimeSpanHelper.ParseDuration(format));
}
