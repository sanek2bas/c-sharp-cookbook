using System.Diagnostics.Contracts;

public class CheckoutStream : IAsyncDisposable, IDisposable
{
    private CancellationTokenSource cancelSource;
    private CancellationToken cancelToken;
    private ILogger log;

    private FileStream asyncDisposeObj;
    private HttpClient syncDisposeObj;

    public CheckoutStream(string filePath)
    {
        cancelSource = new CancellationTokenSource();
        cancelToken = cancelSource.Token;
        log = new ConsoleLogger();

        asyncDisposeObj = new FileStream(
            filePath, FileMode.OpenOrCreate, FileAccess.Write);
        syncDisposeObj = new HttpClient();
    }

    public async IAsyncEnumerable<CheckoutRequest> GetRequestsAsync(
            IProgress<CheckoutRequestProgress> progress)
        {
            int total = 0;
            while (true)
            {
                var requests = new List<CheckoutRequest>();
                try
                {
                    requests = await GetNextBatchAsync();
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                total += requests.Count;
                foreach (var request in requests)
                {
                    if (cancelToken.IsCancellationRequested)
                        break;
                    yield return request;
                }

                progress.Report(
                    new CheckoutRequestProgress
                    {
                        Total = total,
                        Message = "New Batch of Checkout Requests"
                    });


                if (cancelToken.IsCancellationRequested)
                    break;

                await Task.Delay(1000);
            }
        }

        private async Task<List<CheckoutRequest>> GetNextBatchAsync()
        {
            if (cancelToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var requests = new List<CheckoutRequest>
            {
                new CheckoutRequest
                {
                    ShoppingCartID = Guid.NewGuid(),
                    Address = "123 4th St",
                    Card = "1234 5678 9012 3456",
                    Name = "First Card Name"
                },
                new CheckoutRequest
                {
                    ShoppingCartID = Guid.NewGuid(),
                    Address = "789 1st Ave",
                    Card = "2345 6789 0123 4567",
                    Name = "Second Card Name"
                },
                new CheckoutRequest
                {
                    ShoppingCartID = Guid.NewGuid(),
                    Address = "123 4th St",
                    Card = "1234 5678 9012 3456",
                    Name = "First Card Name"
                }
            };

            return await Task.FromResult(requests);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                syncDisposeObj?.Dispose();
                (asyncDisposeObj as IDisposable)?.Dispose();
            }

            DisposeThisObject();
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (asyncDisposeObj is not null)
            {
                await asyncDisposeObj.DisposeAsync().ConfigureAwait(false);
            }

            if (syncDisposeObj is IAsyncDisposable disposable)
            {
                await disposable.DisposeAsync().ConfigureAwait(false);
            }
            else
            {
                syncDisposeObj.Dispose();
            }

            DisposeThisObject();

            await log.WriteAsync("\n\nDisposed!");
        }

        private void DisposeThisObject()
        {
            cancelSource.Cancel();

            asyncDisposeObj = null;
            syncDisposeObj = null;
        }
}