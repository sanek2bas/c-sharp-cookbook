internal class Program
{
    private static void Main(string[] args)
    {
        var fileName = "Invoice.txt";
        var baseDirectory = GetDataFolder(AppDomain.CurrentDomain.BaseDirectory,
                                          AppDomain.CurrentDomain.FriendlyName);
        var filePath = $"{baseDirectory}\\{fileName}";
        Console.WriteLine(
               "Invoice App\n" +
               "-----------\n");
        WriteDetails(filePath);
        ReadDetails(filePath);
    }

    private static void WriteDetails(string filePath)
    {
        using var writer = new StreamWriter(filePath);
        Console.WriteLine("Type details and press [Enter] to end.\n");
        string detail;
        do
        {
            Console.Write("Detail: ");
            detail = Console.ReadLine();
            writer.WriteLine(detail);
        }
        while (!string.IsNullOrWhiteSpace(detail));
    }

    private static void ReadDetails(string filePath)
    {
        Console.WriteLine("\nInvoice Details:\n");
        using var reader = new StreamReader(filePath);
        string detail;
        do
        {
            detail = reader.ReadLine();
            Console.WriteLine(detail);
        }
        while (!string.IsNullOrWhiteSpace(detail));
    }

    private static string GetDataFolder(string startDirectory, string targetFolder)
    {
        var directory = Directory.GetParent(startDirectory);
        while (directory.Name != targetFolder)
            directory = directory.Parent;
        return directory.FullName;
    }
}