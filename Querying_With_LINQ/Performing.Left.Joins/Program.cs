using Performing.Left.Joins;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new InMemoryContext();

        var salesProducts =
            (from product in context.Products
             join person in context.SalesPeople on
             (product.Region, product.Type)
             equals
             (person.Region, person.ProductType)
             into prodPersonTemp
             from prodPerson in prodPersonTemp.DefaultIfEmpty()
             select new
             {
                 Person = prodPerson?.Name ?? "(none)",
                 Product = product.Name,
                 product.Region,
                 product.Type
             })
             .ToList();
        
        Console.WriteLine("Sales People\n");
        salesProducts.ForEach(salesProd =>
            Console.WriteLine(
                $"Person: {salesProd.Person}\n" +
                $"Product: {salesProd.Product}\n" +
                $"Region: {salesProd.Region}\n" +
                $"Type: {salesProd.Type}\n"));
    }
}