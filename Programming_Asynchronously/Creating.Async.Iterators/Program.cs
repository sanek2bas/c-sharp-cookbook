using Creating.Async.Iterators;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var checkoutSvc = new CheckoutService();
        var checkoutStrm = new CheckoutStream();
        await foreach (var request in checkoutStrm.GetRequestsAsync())
        {
            string result = await checkoutSvc.StartAsync(request);
            Console.WriteLine($"Result: {result}");
        }
    }
}