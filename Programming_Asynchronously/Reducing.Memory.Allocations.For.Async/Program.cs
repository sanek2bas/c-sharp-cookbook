using Reducing.Memory.Allocations.For.Async;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var checkoutSvc = new CheckoutService();
        string result = await checkoutSvc.StartAsync();
        Console.WriteLine($"Result: {result}");
    }
}