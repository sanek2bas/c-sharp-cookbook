public abstract class DeliveryBase
{
    public abstract AddressBase GetAddress(string name);
}

public class Communications : DeliveryBase
{
    public override MailingAddress GetAddress(string name)
    {
        return new(
            Street: "567 8th Ave.", 
            City: "Some Place", 
            State: "YY", 
            Zip: "12345-7890", 
            Email: "me@example.com", 
            PreferEmail: true);
    }
}
    
public class Shipping : DeliveryBase
{
    public override ShippingAddress GetAddress(string name)
    {
        return new(
            street: "567 8th Ave.",
            city: "Some Place",
            state: "YY",
            zip: "12345-7890",
            deliveryInstructions: "Ring Doorbell");
    }
}