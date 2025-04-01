namespace Rethrowing.Exceptions
{
    public class Orders
    {
        public void Process()
        {
            throw new IndexOutOfRangeException("Expected 10 orders, but found only 9.");
        }
    }
}
