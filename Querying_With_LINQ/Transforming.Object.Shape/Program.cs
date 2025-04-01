using Transforming.Object.Shape;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new InMemoryContext();

        var salesPersonLookup =
            (from person in context.SalesPeople
             select (person.ID, person.Name))
            .ToList();

        Console.WriteLine("Sales People\n");

        salesPersonLookup.ForEach(person => 
            Console.WriteLine($"{person.ID}. {person.Name}"));
    }
}