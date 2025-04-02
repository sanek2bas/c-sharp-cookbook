using Reducing.Instantiation.Syntax;

internal class Program
{
    Address addressOld = new Address();
    Address addressNew = new();

    private static void Main(string[] args)
    {
        var addressLocalVar = new Address();
        Address addressLocalOld = new Address();
        Address addressLocalNew = new();
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