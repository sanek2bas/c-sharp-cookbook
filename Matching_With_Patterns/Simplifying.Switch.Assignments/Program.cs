using Simplifying.Switch.Assignments;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Choose (1) Bronze, (2) Silver, or (3) Gold: ");
        string choice = Console.ReadLine();
        Enum.TryParse(choice, out ScheduleType scheduleType);

        var scheduler = new Scheduler();
        
        IRoomSchedule scheduleStatement = 
            scheduler.CreateStatement(scheduleType);
        scheduleStatement.ScheduleRoom();

        IRoomSchedule scheduleExpression = 
            scheduler.CreateExpression(scheduleType);
        scheduleExpression.ScheduleRoom();
    }
}