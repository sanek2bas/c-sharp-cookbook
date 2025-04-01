using Customizing.Class.String.Representation;

internal class Program
{
    private static void Main(string[] args)
    {
        var order = new Order
        {
            ID = 7,
            CustomerName = "Acme",
            Created = DateTime.Now,
            Amount = 2_718_281.83m
        };
        Console.WriteLine(order);
    }
}