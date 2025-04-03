using Slicing.Arrays;

internal class Program
{
    private static void Main(string[] args)
    {
        AddressService addressSvc = new();
        foreach(var addresses in addressSvc.GetAddresses(3))
        {
            foreach(var address in addresses)
                Console.WriteLine(address);
            Console.WriteLine("\nNew Page\n");
        }
    }
}