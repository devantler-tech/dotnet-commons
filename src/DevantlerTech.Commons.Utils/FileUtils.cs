namespace DevantlerTech.Commons.Utils;


/// <summary>
/// Helper class for file access operations.
/// </summary>
public static class FileHelper
{
  /// <summary>
  /// Helper method to retry file access operations with a timeout.
  /// </summary>
  /// <param name="fileAccessAction"></param>
  /// <param name="timeoutInSeconds"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  /// <exception cref="TimeoutException"></exception>
  public static async Task RetryFileAccessAsync(Func<Task> fileAccessAction, int timeoutInSeconds = 5, CancellationToken cancellationToken = default)
  {
    ArgumentNullException.ThrowIfNull(fileAccessAction);
    using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutInSeconds));
    using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

    while (true)
    {
      try
      {
        await fileAccessAction().ConfigureAwait(false);
        break; // Exit the loop if the file access succeeds.
      }
      catch (IOException)
      {
        // Wait and retry if the file is locked.
        await Task.Delay(100, linkedCts.Token).ConfigureAwait(false);
      }
    }
  }
}
