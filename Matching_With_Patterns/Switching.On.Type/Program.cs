using Switching.On.Type;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (var customer in GetCustomers())
        {
            IRoomSchedule schedule = GetSchedule(customer);
            schedule.ScheduleRoom();
        }
    }

    private static List<Customer> GetCustomers() =>
        new List<Customer>
        {
            new GoldCustomer(),
            new SilverCustomer(),
            new BronzeCustomer()
        };

    private static IRoomSchedule GetSchedule(Customer customer) =>
        customer switch
        {
            GoldCustomer => new GoldSchedule(),
            SilverCustomer => new SilverSchedule(),
            BronzeCustomer => new BronzeSchedule(),
            _ => new BronzeSchedule()
        };
}