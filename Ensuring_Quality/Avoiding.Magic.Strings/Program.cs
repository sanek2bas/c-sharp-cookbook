using Avoiding.Magic.Strings;

internal class Program
{
    private static void Main(string[] args)
    {
        var orders = new List<Order>
        {
            new Order { DeliveryInstructions = Delivery.LowFare },
            new Order { DeliveryInstructions = Delivery.NextDay },
            new Order { DeliveryInstructions = Delivery.Standard },
        };

        foreach (var order in orders)
        {
            int days;
            switch (order.DeliveryInstructions)
            {
                case Delivery.LowFare:
                    days = 15;
                    break;
                case Delivery.NextDay:
                    days = 1;
                    break;
                case Delivery.Standard:
                default:
                    days = Delivery.StandardDays;
                    break;
            }

            Console.WriteLine(order.DeliveryInstructions);
            Console.WriteLine($"Expected Delivery Day(s): {days}");
        }
    }
}