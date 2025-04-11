internal class Program
{
    private static async Task Main(string[] args)
    {
        var cancelSource = new CancellationTokenSource();
        var checkoutStrm = new CheckoutStream(cancelSource.Token);
        var checkoutSvc = new CheckoutService();
        IProgress<CheckoutRequestProgress> progress =
        new Progress<CheckoutRequestProgress>(p =>
        {
            Console.WriteLine(
                $"\n" +
                $"Total: {p.Total}, " +
                $"{p.Message}" +
                $"\n");
        });
        
        int count = 1;
        await foreach (var request in
                checkoutStrm.GetRequestsAsync(progress))
                {
                    string result = await checkoutSvc.StartAsync(request);
                    Console.WriteLine($"Result: {result}");
                    if (count++ >= 10)
                        break;
                    if (count >= 5)
                        cancelSource.Cancel();
                }
        }
}