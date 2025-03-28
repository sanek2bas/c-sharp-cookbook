internal class Program
{
    private static void Main(string[] args)
    {
        var fileName = "DeploymentReport.txt";
        var baseDirectory = GetDataFolder(AppDomain.CurrentDomain.BaseDirectory, 
                                          AppDomain.CurrentDomain.FriendlyName);
        var filepath = $"{baseDirectory}\\{fileName}";
        
        bool checkStatus = false;
        using(var deployer = new DeploymentProcess(filepath))
        {
            checkStatus = deployer.CheckStatus();
        }
        Console.WriteLine($"CheckStatus: {checkStatus}");
    }

    private static string GetDataFolder(string startDirectory, string targetFolder)
    {
        var directory = Directory.GetParent(startDirectory);
        while (directory.Name != targetFolder)
               directory = directory.Parent;
        return directory.FullName;
    }
}