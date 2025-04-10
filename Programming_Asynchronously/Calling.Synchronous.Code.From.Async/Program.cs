using Calling.Synchronous.Code.From.Async;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var checkoutSvc = new CheckoutService();
        string result = await checkoutSvc.StartAsync();
        Console.WriteLine($"Result: {result}");
    }
}