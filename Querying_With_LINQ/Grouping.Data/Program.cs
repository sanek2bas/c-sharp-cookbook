using Grouping.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new InMemoryContext();

        var salesPeopleByRegion =
            (from person in context.SalesPeople
             group person by person.Region
             into personGroup
             select personGroup)
             .ToList();

        Console.WriteLine("Sales People by Region");
        foreach (var region in salesPeopleByRegion)
        {
            Console.WriteLine($"\nRegion: {region.Key}");
            foreach (var person in region)
                Console.WriteLine($" {person.Name}");
        }
    }
}