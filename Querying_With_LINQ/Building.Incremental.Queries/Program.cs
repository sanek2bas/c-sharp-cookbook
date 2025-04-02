using Building.Incremental.Queries;

internal class Program
{
    private static void Main(string[] args)
    {
        SalesPerson searchCriteria = GetCriteriaFromUser();
        List<SalesPerson> salesPeople = QuerySalesPeople(searchCriteria);
        PrintResults(salesPeople);
    }

    private static void PrintResults(List<SalesPerson> salesPeople)
    {
        Console.WriteLine("\nSales People\n");
        salesPeople.ForEach(person =>
            Console.WriteLine($"{person.ID}. {person.Name}"));
    }

    private static List<SalesPerson> QuerySalesPeople(SalesPerson criteria)
    {
        var ctx = new InMemoryContext();
        IEnumerable<SalesPerson> salesPeopleQuery =
            from people in ctx.SalesPeople
            select people;

        if (!string.IsNullOrWhiteSpace(criteria.Address))
            salesPeopleQuery = salesPeopleQuery.Where(
                person => person.Address == criteria.Address);

        if (!string.IsNullOrWhiteSpace(criteria.City))
            salesPeopleQuery = salesPeopleQuery.Where(
                person => person.City == criteria.City);

        if (!string.IsNullOrWhiteSpace(criteria.Name))
            salesPeopleQuery = salesPeopleQuery.Where(
                person => person.Name == criteria.Name);
        
        if (!string.IsNullOrWhiteSpace(criteria.PostalCode))
            salesPeopleQuery = salesPeopleQuery.Where(
                person => person.PostalCode == criteria.PostalCode);
        
        if (!string.IsNullOrWhiteSpace(criteria.ProductType))
            salesPeopleQuery = salesPeopleQuery.Where(
                person => person.ProductType == criteria.ProductType);
        
        if (!string.IsNullOrWhiteSpace(criteria.Region))
            salesPeopleQuery = salesPeopleQuery.Where(
                person => person.Region == criteria.Region);
        
        return salesPeopleQuery.ToList();
    }

    private static SalesPerson GetCriteriaFromUser()
    {
        var person = new SalesPerson();
        Console.WriteLine("Sales Person Search");
        Console.WriteLine("(press Enter to skip an entry)\n");
        Console.Write($"{nameof(SalesPerson.Address)}: ");
        person.Address = Console.ReadLine();
        Console.Write($"{nameof(SalesPerson.City)}: ");
        person.City = Console.ReadLine();
        Console.Write($"{nameof(SalesPerson.Name)}: ");
        person.Name = Console.ReadLine();
        Console.Write($"{nameof(SalesPerson.PostalCode)}: ");
        person.PostalCode = Console.ReadLine();
        Console.Write($"{nameof(SalesPerson.ProductType)}: ");
        person.ProductType = Console.ReadLine();
        Console.Write($"{nameof(SalesPerson.Region)}: ");
        person.Region = Console.ReadLine();
        return person;
    }
}