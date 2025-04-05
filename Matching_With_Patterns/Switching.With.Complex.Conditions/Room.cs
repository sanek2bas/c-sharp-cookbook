namespace Switching.With.Complex.Conditions
{
    public interface IRoomSchedule
    {
        void ScheduleRoom();
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
}
