using Updating.Progress.Asynchronously;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var checkoutSvc = new CheckoutService();
        var checkoutStrm = new CheckoutStream();

        IProgress<CheckoutRequestProgress> progress =
            new Progress<CheckoutRequestProgress>(p =>
            {
                Console.WriteLine(
                    $"\n" +
                    $"Total: {p.Total}, " +
                    $"{p.Message}" +
                    $"\n");
            });

        await foreach (var request in
            checkoutStrm.GetRequestsAsync(progress))
        {
            string result = await checkoutSvc.StartAsync(request);
            Console.WriteLine($"Result: {result}");
        }
    }
}