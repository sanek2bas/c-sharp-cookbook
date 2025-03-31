namespace Versioning.Interfaces.Safely
{
    public class CompanyOrder : IOrderNew
    {
        decimal total = 25.00m;
        public string PrintOrder()
        {
            return "Company Order Details";
        }
        public decimal GetRewards()
        {
            return total * 0.01m;
        }
    }
}
