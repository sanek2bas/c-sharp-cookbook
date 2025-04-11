internal class Program
{
    private static async Task Main(string[] args)
    {
        var fileName = "DeploymentReport.txt";
        var baseDirectory = GetDataFolder(AppDomain.CurrentDomain.BaseDirectory, 
                                          AppDomain.CurrentDomain.FriendlyName);
        var filepath = $"{baseDirectory}\\{fileName}";

        await using var checkoutStrm = new CheckoutStream(filepath);
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
        }
    }

    private static string GetDataFolder(string startDirectory, string targetFolder)
    {
        var directory = Directory.GetParent(startDirectory);
        while (directory.Name != targetFolder)
               directory = directory.Parent;
        return directory.FullName;
    }
}