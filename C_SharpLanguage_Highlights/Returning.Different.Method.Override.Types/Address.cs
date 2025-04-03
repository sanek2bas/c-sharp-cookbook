public abstract record AddressBase(
    string Street, string City, string State, string Zip);

public record MailingAddress(
    string Street, string City, string State, string Zip, string Email, bool PreferEmail)
    : AddressBase(Street, City, State, Zip);

public record ShippingAddress : AddressBase
{
    public ShippingAddress(
        string street, string city, string state, string zip, string deliveryInstructions)
        : base(street, city, state, zip)
    {
        if (street.Contains("P.O. Box"))
            throw new ArgumentException("P.O. Boxes aren't allowed");
        DeliveryInstructions = deliveryInstructions;
    }
    public string DeliveryInstructions { get; init; }
}