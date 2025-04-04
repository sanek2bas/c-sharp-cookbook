using System.Collections;
using Converting.Instances.Safely;

internal class Program
{
    private static void Main(string[] args)
    {
        ProcessLegacyCode();
        ProcessModernCode();
    }

    private static void ProcessModernCode()
    {
        List<IRoomSchedule> schedules = GetStrongTypedSchedules();
        foreach (var schedule in schedules)
        {
            schedule.ScheduleRoom();
            if (schedule is GoldSchedule gold)
                Console.WriteLine($"Extra processing for {gold.GetType()}");
}
    }

    private static List<IRoomSchedule> GetStrongTypedSchedules()
    {
        return new List<IRoomSchedule>
        {
            new BronzeSchedule(),
            new SilverSchedule(),
            new GoldSchedule()
        };
}

    private static void ProcessLegacyCode()
    {
        ArrayList schedules = GetWeakTypedSchedules();
        foreach (var schedule in schedules)
        {
            if (schedule is IRoomSchedule)
            {
                IRoomSchedule roomSchedule = (IRoomSchedule)schedule;
                roomSchedule.ScheduleRoom();
            }

            IRoomSchedule asRoomSchedule = schedule as IRoomSchedule;
            if (asRoomSchedule != null)
                asRoomSchedule.ScheduleRoom();
            
            if (schedule is IRoomSchedule isRoomSchedule)
                isRoomSchedule.ScheduleRoom();
        }
    }

    private static ArrayList GetWeakTypedSchedules()
    {
        var list = new ArrayList();
        list.Add(new BronzeSchedule());
        list.Add(new SilverSchedule());
        list.Add(new GoldSchedule());
        return list;
    }
}