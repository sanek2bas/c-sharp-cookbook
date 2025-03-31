internal class Program
{
    private static void Main(string[] args)
    {
        var lineItems = GetInvoiceItems();
        decimal total = 0;
        foreach (var item in lineItems)
            total += item.Cost;
        total = ApplyDiscount(total, CustomerType.Gold);
        Console.WriteLine($"Total Invoice Balance: {total:C}");
    }

    private static IList<InvoiceItem> GetInvoiceItems()
    {
        var items = new List<InvoiceItem>();
        var rand = new Random();
        for(int i = 0; i < 100; i++)
        {
            items.Add(
                new InvoiceItem
                {
                    Cost = rand.Next(i),
                    Description = $"Invoice item #{i+1}"
                }
            );
        }
        return items;
    }
    
    private static decimal ApplyDiscount(decimal total, CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.Bronze => total - total * .10m,
            CustomerType.Silver => total - total * .05m,
            CustomerType.Gold => total - total * .02m,
            _ => total
        };
    }
}