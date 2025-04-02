using Querying.In.Parallel;

internal class Program
{
    private static void Main(string[] args)
    {
        List<SalesPerson> salesPeople = new InMemoryContext().SalesPeople;
        var result =
            (from person in salesPeople.AsParallel()
             select ProcessPerson(person))
             .ToList();
    }

    private static SalesPerson ProcessPerson(SalesPerson person)
    {
        Console.WriteLine(
            $"Starting sales person #{person.ID}. {person.Name}");
        // complex in-memory processing
        Thread.Sleep(500);
        Console.WriteLine(
        $"Completed sales person #{person.ID}. {person.Name}");
        return person;
    }
}