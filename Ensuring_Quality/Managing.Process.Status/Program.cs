internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Processing Orders Started");
            ProcessOrders();
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine('\n' + ae.ToString() + '\n');
        }
        finally
        {
            Console.WriteLine("Processing Orders Complete");
        }
    }

    private static void ProcessOrders()
    {
        throw new ArgumentException();
    }
}