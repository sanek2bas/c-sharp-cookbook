using Initializing.Entire.Modules;

internal class Program
{
    private static void Main(string[] args)
    {
        AddressService addressSvc = AddressService.Create();
        addressSvc.GetAddresses()
                  .ForEach(address => Console.WriteLine(address));
    }
}