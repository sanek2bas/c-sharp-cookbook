using Initializing.Immutable.State;

internal class Program
{
    private static void Main(string[] args)
    {
        Address addressObjectInit = new()
        {
            Street = "123 4th St.",
            City = "My City",
            State = "ZZ",
            Zip = "55555-3333"
        };

        Address addressCtorInit = new(
            street: "567 8th Ave.",
            city: "Some Place",
            state: "YY",
            zip: "12345-7890");
    }
}