using Measuring.Performance;
using System.Diagnostics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        List<OrderItem> lineItems = GetOrderItems();
        DoStringConcatenation(lineItems);
        DoStringBuilderConcatenation(lineItems);
    }

    private static string DoStringConcatenation(List<OrderItem> lineItems)
    {
        var stopwatch = new Stopwatch();
        try
        {
            stopwatch.Start();
            string report = "";
            foreach (var item in lineItems)
                report += $"{item.Cost:C} - {item.Description}\n";
            Console.WriteLine(
                $"Time for String Concatenation: " +
                $"{stopwatch.ElapsedMilliseconds}");
            return report;
        }
        finally
        {
            stopwatch.Stop();
        }
    }

    private static string DoStringBuilderConcatenation(List<OrderItem> lineItems)
    {
        var stopwatch = new Stopwatch();
        try
        {
            stopwatch.Start();
            var reportBuilder = new StringBuilder();
            foreach (var item in lineItems)
                reportBuilder.Append($"{item.Cost:C} - {item.Description}\n");
            Console.WriteLine(
                $"Time for String Builder Concatenation: " +
                $"{stopwatch.ElapsedMilliseconds}");
            return reportBuilder.ToString();
        }
        finally
        {
            stopwatch.Stop();
        }
    }

    private static List<OrderItem> GetOrderItems()
    {
        const int ItemCount = 10000;
        var items = new List<OrderItem>();
        var rand = new Random();
        for (int i = 0; i < ItemCount; i++)
            items.Add(
                new OrderItem
                {
                    Cost = rand.Next(i),
                    Description = "Order Item #" + (i + 1)
                });
        return items;
    }
}