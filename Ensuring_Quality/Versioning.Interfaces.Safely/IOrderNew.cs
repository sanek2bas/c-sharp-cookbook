namespace Versioning.Interfaces.Safely
{
    public interface IOrderNew
    {
        string PrintOrder();

        decimal GetRewards() => 0.00m;
    }
}
