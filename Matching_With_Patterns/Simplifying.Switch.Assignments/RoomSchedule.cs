namespace Simplifying.Switch.Assignments;

public interface IRoomSchedule
{
    void ScheduleRoom();
}

public enum ScheduleType
{
    None,
    Bronze,
    Silver,
    Gold
}

public class GoldSchedule : IRoomSchedule
{
    public void ScheduleRoom() =>
        Console.WriteLine("Scheduling Gold Room");
}

public class SilverSchedule : IRoomSchedule
{
    public void ScheduleRoom() =>
        Console.WriteLine("Scheduling Silver Room");
}

public class BronzeSchedule : IRoomSchedule
{
    public void ScheduleRoom() =>
        Console.WriteLine("Scheduling Bronze Room");
}

public class Scheduler
{
    public IRoomSchedule CreateStatement(ScheduleType scheduleType)
    {
        switch (scheduleType)
        {
            case ScheduleType.Gold:
                return new GoldSchedule();
            case ScheduleType.Silver:
                return new SilverSchedule();
            case ScheduleType.Bronze:
            default:
                return new BronzeSchedule();
        }
    }
        
    public IRoomSchedule CreateExpression(
        ScheduleType scheduleType) =>
        scheduleType switch
        {
            ScheduleType.Gold => new GoldSchedule(),
            ScheduleType.Silver => new SilverSchedule(),
            ScheduleType.Bronze => new BronzeSchedule(),
            _ => new BronzeSchedule()
        };
}