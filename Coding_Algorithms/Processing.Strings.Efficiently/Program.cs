using Processing.Strings.Efficiently;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var lineItems = GetInvoiceItems();

        var string1 = DoStringConcatenation(lineItems);
        Console.WriteLine(string1);

        Console.WriteLine();

        var string2 = DoStringBuilderConcatenation(lineItems);
        Console.WriteLine(string2);
    }

    private static IList<InvoiceItem> GetInvoiceItems()
    {
        var items = new List<InvoiceItem>();
        var rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            items.Add(
                new InvoiceItem
                {
                    Cost = rand.Next(i),
                    Description = "Invoice Item #" + (i + 1)
                });
        }
        return items;
    }

    private static string DoStringConcatenation(IList<InvoiceItem> lineItems)
    {
        string report = "";
        foreach (var item in lineItems)
            report += $"{item.Cost:C} - {item.Description}\n";
        return report;
    }

    private static string DoStringBuilderConcatenation(IList<InvoiceItem> lineItems)
    {
        var reportBuilder = new StringBuilder();
        foreach (var item in lineItems)
            reportBuilder.Append($"{item.Cost:C} - {item.Description}\n");
        return reportBuilder.ToString();
    }
}