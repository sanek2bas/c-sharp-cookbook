using Handling.Parallel.Tasks.As.They.Complete;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var checkoutSvc = new CheckoutService();

            string result = await checkoutSvc.StartBigO1Async();
            //string result = await checkoutSvc.StartBigONAsync();
            //string result = await checkoutSvc.StartBigONSquaredAsync();

            Console.WriteLine($"Result: {result}");
        }
        catch (AggregateException aEx)
        {
            foreach (var ex in aEx.InnerExceptions)
                Console.WriteLine($"Unable to complete: {ex}");
        }
    }
}