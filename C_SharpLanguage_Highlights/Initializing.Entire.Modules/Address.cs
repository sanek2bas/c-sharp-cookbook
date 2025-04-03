using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace Initializing.Entire.Modules;

public record Address(string Street, string City, string State, string Zip);

public interface IAddressRepository
{
    List<Address> GetAddresses();
}

public class AddressRepository : IAddressRepository
{
    public List<Address> GetAddresses() =>
        new List<Address>
        {
            new (Street: "123 4th St.",
                 City: "My Place",
                 State: "ZZ",
                 Zip: "12345-7890"),
            new (Street: "567 8th Ave.",
                 City: "Some Place",
                 State: "YY",
                 Zip: "12345-7890"),
            new (Street: "567 8th Ave.",
                 City: "Some Place",
                 State: "YY",
                 Zip: "12345-7890")
        };
}

public class Initializer
{
    internal static ServiceProvider Container { get; set; }
    
    [ModuleInitializer]
    internal static void InitAddressUtilities()
    {
        var services = new ServiceCollection();
        services.AddTransient<AddressService>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        Container = services.BuildServiceProvider();
    }
}

public class AddressService
{
    readonly IAddressRepository addressRep;
    
    public AddressService(IAddressRepository addressRep) =>
        this.addressRep = addressRep;
    
    public static AddressService Create() =>
        Initializer.Container.GetRequiredService<AddressService>();
    public List<Address> GetAddresses() =>
        (from address in addressRep.GetAddresses()
         select address)
         .Distinct()
         .ToList();
}
