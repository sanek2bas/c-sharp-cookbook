using Versioning.Interfaces.Safely;

internal class Program
{
    private static void Main(string[] args)
    {
        var orders = new List<IOrderNew>
        {
            new CustomerOrder(),
            new CompanyOrder()
        };

        foreach (var order in orders)
        {
            Console.WriteLine(order.PrintOrder());
            Console.WriteLine($"Rewards: {order.GetRewards()}");
        }
    }
}