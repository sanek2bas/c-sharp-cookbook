using Creating.Async.Console.Applications;

internal class Program
{
    static async Task Main(string[] args)
    {
        var checkoutSvc = new CheckoutService();
        string result = await checkoutSvc.StartAsync();
        Console.WriteLine($"Result: {result}");
    }
}