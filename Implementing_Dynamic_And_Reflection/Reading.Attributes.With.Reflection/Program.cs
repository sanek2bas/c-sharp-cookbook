using Reading.Attributes.With.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var inventory = new List<object>
        {
            new InventoryItem
            {
                PartNumber = "1",
                Description = "Part #1",
                Count = 3,
                ItemPrice = 5.26m
            },
            new InventoryItem
            {
                PartNumber = "2",
                Description = "Part #2",
                Count = 1,
                ItemPrice = 7.95m
            },
            new InventoryItem
            {
                PartNumber = "3",
                Description = "Part #3",
                Count = 2,
                ItemPrice = 23.13m
            },
        };
        
        string report = new Report().Generate(inventory);
        Console.WriteLine(report);
    }
}