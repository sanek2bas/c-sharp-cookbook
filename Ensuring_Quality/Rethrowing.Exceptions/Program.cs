using Rethrowing.Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException +=
            (object sender, UnhandledExceptionEventArgs e) => 
            Console.WriteLine("\n\nUnhandled Exception:\n" + e);

        try
        {
            OrderOrchestrator.HandleOrdersWrong();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Handle Orders Wrong:\n" + ex);
        }

        try
        {
            OrderOrchestrator.HandleOrdersBetter1();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("\n\nHandle Orders Better #1:\n" + ex);
        }

        try
        {
            OrderOrchestrator.HandleOrdersBetter2();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("\n\nHandle Orders Better #2:\n" + ex);
        }

        OrderOrchestrator.DontHandleOrders();
    }
}