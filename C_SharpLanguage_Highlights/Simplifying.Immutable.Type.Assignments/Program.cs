internal class Program
{
    private record Address(string Street, string City, string State, string Zip);

    private static void Main(string[] args)
    {
        Address addressPre = new(
            Street: "567 8th Ave.",
            City: "Some Place",
            State: "YY",
            Zip: "12345-7890");
        Address addressPost =
            addressPre with
            {
                Street = "569 8th Ave."
            };
        Console.WriteLine($"Pre: {addressPre}");
        Console.WriteLine($"Post: {addressPost}");
        Console.WriteLine(
            $"Value Equal: " +
            $"{addressPre == addressPost}");
    }
}