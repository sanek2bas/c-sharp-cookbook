using Switching.On.Tuples;

internal class Program
{
    const int RoomNotAvailable = -1;

    private static void Main(string[] args)
    {
        Console.Write(
            "Choose (1) Bronze, (2) Silver, or (3) Gold: ");
        string choice = Console.ReadLine();

        Enum.TryParse(choice, out ScheduleType scheduleType);

        int roomNumber = AssignRoom(scheduleType);
        if (roomNumber == RoomNotAvailable)
            Console.WriteLine("Room not available.");
        else
            Console.WriteLine($"The room number is {roomNumber}.");
    }

    private static int AssignRoom(ScheduleType scheduleType)
    {
        foreach (var room in GetRooms())
        {
            ScheduleType roomType = room switch
            {
                ("King", "Suite") => ScheduleType.Gold,
                ("King", "Regular") => ScheduleType.Silver,
                ("Queen", "Regular") => ScheduleType.Bronze,
                _ => ScheduleType.Bronze
            };
            if (roomType == scheduleType)
                return room.Number;
        }
        return RoomNotAvailable;
    }

    private static List<Room> GetRooms()
    {
        return new List<Room>
        {
            new Room
            {
                Number = 333,
                BedSize = "King",
                RoomType = "Suite"
            },
            new Room
            {
                Number = 222,
                BedSize = "King",
                RoomType = "Regular"
            },
            new Room
            {
                Number = 111,
                BedSize = "Queen",
                RoomType = "Regular"
            }
        };
    }
}