using Querying.Distinct.Objects;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new InMemoryContext();

        var salesPeopleWithoutComparer =
            (from person in context.SalesPeople
             select person)
             .Distinct()
             .ToList();

        PrintResults(salesPeopleWithoutComparer, "Without Comparer");

        var salesPeopleWithComparer =
            (from person in context.SalesPeople
             select person)
             .Distinct(new SalesPersonComparer())
             .ToList();

        PrintResults(salesPeopleWithComparer, "With Comparer");
    }

    private static void PrintResults(List<SalesPerson> salesPeople, string title)
    {
        Console.WriteLine($"\n{title}\n");
        salesPeople.ForEach(person =>
            Console.WriteLine($"{person.ID}. {person.Name}"));
    }
}