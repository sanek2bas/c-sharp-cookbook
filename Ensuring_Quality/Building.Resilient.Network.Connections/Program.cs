using System.Net;

internal class Program
{
    static async Task Main(string[] args)
    {
        const int DelayMilliseconds = 500;
        const int RetryCount = 3;

        bool success = false;
        int tryCount = 0;

        try
        {
            do
            {
                try
                {
                    Console.WriteLine("Getting Orders");
                    await GetOrdersAsync();
                    success = true;
                }
                catch(HttpRequestException hre)
                    when (hre.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    tryCount++;
                    int msToDelay = DelayMilliseconds * tryCount;
                    Console.WriteLine(
                        $"Exception during processing—delaying for {msToDelay} milliseconds");
                }
            }
            while (tryCount < RetryCount);
        }
        finally
        {

        }
    }

    private static async Task GetOrdersAsync()
    {
        throw await Task.FromResult(
            new HttpRequestException(
                "Timeout", null, HttpStatusCode.RequestTimeout));
    }
}