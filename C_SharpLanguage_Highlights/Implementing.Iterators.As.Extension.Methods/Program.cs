using Implementing.Iterators.As.Extension.Methods;

internal class Program
{
    private static void Main(string[] args)
    {
        IEnumerable<Address> addresses = GetAddresses();
        foreach (var address in addresses)
        {
            foreach (var line in address)
            Console.WriteLine(line);
        Console.WriteLine();
        }
    }

    private static IEnumerable<Address> GetAddresses()
    {
        return new List<Address>
        {
            new Address(
                Street: "567 8th Ave.",
                City: "Some Place",
                State: "YY",
                Zip: "12345-7890"),
            new Address(
                Street: "569 8th Ave.",
                City: "Some Place",
                State: "YY",
                Zip: "12345-7890")
        };
    }
}