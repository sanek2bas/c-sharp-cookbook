namespace Initializing.Immutable.State
{
    public class Address
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Zip { get; init; }

        public Address() { }

        public Address(
            string street,
            string city,
            string state,
            string zip)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }
    }
}
