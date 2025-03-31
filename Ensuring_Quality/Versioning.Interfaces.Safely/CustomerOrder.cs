namespace Versioning.Interfaces.Safely
{
    public class CustomerOrder : IOrderNew
    {
        public string PrintOrder()
        {
            return "Customer Order Details";
        }
    }
}
