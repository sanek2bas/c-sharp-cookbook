using Switching.On.Value.Ranges;

internal class Program
{
    const int SilverPoints = 5000;
    const int GoldPoints = 20000;

    private static void Main(string[] args)
    {
        Console.Write("How many points? ");
        string response = Console.ReadLine();
        if (!int.TryParse(response, out int points))
        {
            Console.WriteLine($"'{response}' is invalid!");
            return;
        }
        IRoomSchedule schedule = GetSchedule(points);
        schedule.ScheduleRoom();
    }

    
    static IRoomSchedule GetSchedule(int points) =>
        points switch
        {
            >= GoldPoints => new GoldSchedule(),
            >= SilverPoints => new SilverSchedule(),
            < SilverPoints => new BronzeSchedule()
        };
}