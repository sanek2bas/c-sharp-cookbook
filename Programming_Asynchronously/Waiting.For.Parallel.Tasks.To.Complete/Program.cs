using Waiting.For.Parallel.Tasks.To.Complete;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var checkoutSvc = new CheckoutService();
            string result = await checkoutSvc.StartAsync();
            Console.WriteLine($"Result: {result}");
        }
        catch (AggregateException aEx)
        {
            foreach (var ex in aEx.InnerExceptions)
                Console.WriteLine($"Unable to complete: {ex}");
        }
    }
}