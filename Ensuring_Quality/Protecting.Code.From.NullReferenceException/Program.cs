using Protecting.Code.From.NullReferenceException;

internal class Program
{
    private static void Main(string[] args)
    {
        //HandleWithNullNoHandling();
        HandleWithNullAndHandling();
    }

    private static void HandleWithNullAndHandling()
    {
        var orders = new OrderLibraryWithNull();
        string? deal = orders.DealOfTheDay;
        Console.WriteLine(deal?.ToUpper() ?? "Deals");
        orders.AddItem(null);
        orders.AddItems(new List<string?> { "one", null });
        List<string>? items = orders.GetItems();
        if (items != null)
            foreach (var item in items.ToArray())
                Console.WriteLine(item.Trim());
    }

    private static void HandleWithNullNoHandling()
    {
        var orders = new OrderLibraryWithNull();
        string deal = orders.DealOfTheDay;
        Console.WriteLine(deal.ToUpper());
        orders.AddItem(null);
        orders.AddItems(new List<string> { "one", null });
        foreach (var item in orders.GetItems().ToArray())
            Console.WriteLine(item.Trim());
    }
}