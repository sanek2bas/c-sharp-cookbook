public class Deployment
{
    private string config;

    public Deployment(string config)
    {
        this.config = config;
    }

    public bool PerformHealthCheck()
    {
        Console.WriteLine($"Performed health check for config {config}.");
        return true;
    }
}