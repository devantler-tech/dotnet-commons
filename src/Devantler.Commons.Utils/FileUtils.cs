namespace Devantler.Commons.Utils;


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
  public static async Task RetryFileAccessAsync(Func<Task> fileAccessAction, int timeoutInSeconds = 5, CancellationToken cancellationToken)
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
        if (timeoutCts.Token.IsCancellationRequested)
          throw new TimeoutException($"Failed to access the file within the timeout of {timeoutInSeconds} seconds.");

        // Wait and retry if the file is locked.
        await Task.Delay(100, linkedCts.Token).ConfigureAwait(false);
      }
    }
  }
}