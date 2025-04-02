internal class Program
{
    private record Address(string Street, string City, string State, string Zip);

    private static void Main(string[] args)
    {
        var addressClassic = new Address(
            Street: "567 8th Ave.",
            City: "Some Place",
            State: "YY",
            Zip: "12345-7890");

        Address addressCtorInit = new(
            Street: "567 8th Ave.",
            City: "Some Place",
            State: "YY",
            Zip: "12345-7890");

        Console.WriteLine(
            $"Value Equal: " +
            $"{addressClassic == addressCtorInit}");
        Console.WriteLine(
            $"Reference Equal: " +
            $"{ReferenceEquals(addressClassic, addressCtorInit)}");
        Console.WriteLine(
            $"{nameof(addressClassic)}: {addressClassic}");
        Console.WriteLine(
            $"{nameof(Address)}: {addressCtorInit}");
    }
}