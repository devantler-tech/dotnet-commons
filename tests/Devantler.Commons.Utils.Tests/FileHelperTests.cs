namespace Devantler.Commons.Utils.Tests;

/// <summary>
/// Unit tests for the FileHelper class.
/// </summary>
public class FileHelperTests
{
  /// <summary>
  /// Tests the RetryFileAccessAsync method for successful file access.
  /// </summary>
  /// <returns></returns>
  [Fact]
  public async Task RetryFileAccessAsync_SuccessfulFileAccess_DoesNotThrow()
  {
    // Arrange
    var fileAccessAction = new Func<Task>(() => Task.CompletedTask);

    // Act & Assert
    await FileHelper.RetryFileAccessAsync(fileAccessAction);
  }

  /// <summary>
  /// Tests the RetryFileAccessAsync method for file access that throws an IOException.
  /// </summary>
  /// <returns></returns>
  /// <exception cref="IOException"></exception>
  [Fact]
  public async Task RetryFileAccessAsync_FileAccessThrowsIOException_RetriesUntilSuccess()
  {
    // Arrange
    int attempt = 0;
    var fileAccessAction = new Func<Task>(() =>
    {
      attempt++;
      if (attempt < 3)
        throw new IOException("File is locked.");
      return Task.CompletedTask;
    });

    // Act
    await FileHelper.RetryFileAccessAsync(fileAccessAction);

    // Assert
    Assert.Equal(3, attempt);
  }

  /// <summary>
  /// Tests the RetryFileAccessAsync method for file access that times out.
  /// </summary>
  /// <returns></returns>
  /// <exception cref="IOException"></exception>
  [Fact]
  public async Task RetryFileAccessAsync_FileAccessTimeout_ThrowsTaskCanceledException()
  {
    // Arrange
    var fileAccessAction = new Func<Task>(() => throw new IOException("File is locked."));
    int timeoutInSeconds = 1;

    // Act & Assert
    var exception = await Assert.ThrowsAsync<TaskCanceledException>(async () =>
      await FileHelper.RetryFileAccessAsync(fileAccessAction, timeoutInSeconds).ConfigureAwait(false));
    Assert.Contains($"A task was canceled.", exception.Message, StringComparison.Ordinal);
  }

  /// <summary>
  /// Tests the RetryFileAccessAsync method for file access that times out.
  /// </summary>
  /// <returns></returns>
  /// <exception cref="IOException"></exception>
  [Fact]
  public async Task RetryFileAccessAsync_CancellationRequested_ThrowsTaskCanceledException()
  {
    // Arrange
    var fileAccessAction = new Func<Task>(() => throw new IOException("File is locked."));
    using var cancellationTokenSource = new CancellationTokenSource();
    await cancellationTokenSource.CancelAsync();

    // Act & Assert
    var exception = await Assert.ThrowsAsync<TaskCanceledException>(async () =>
      await FileHelper.RetryFileAccessAsync(fileAccessAction, 20, cancellationToken: cancellationTokenSource.Token).ConfigureAwait(false));
    Assert.Contains($"A task was canceled.", exception.Message, StringComparison.Ordinal);
  }

  /// <summary>
  /// Tests the RetryFileAccessAsync method with a null file access action.
  /// </summary>
  /// <returns></returns>
  [Fact]
  public async Task RetryFileAccessAsync_NullFileAccessAction_ThrowsArgumentNullException()
  {
    // Act & Assert
    await Assert.ThrowsAsync<ArgumentNullException>(() =>
      FileHelper.RetryFileAccessAsync(null!));
  }
}