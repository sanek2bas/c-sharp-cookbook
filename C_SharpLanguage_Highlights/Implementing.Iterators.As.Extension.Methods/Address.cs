using System;
namespace Implementing.Iterators.As.Extension.Methods;

public record Address(
    string Street, string City, string State, string Zip);

public static class AddressExtensions
{
    public static IEnumerator<string> GetEnumerator(
        this Address address)
        {
            yield return address.Street;
            yield return address.City;
            yield return address.State;
            yield return address.Zip;
            yield break;
        }
}
