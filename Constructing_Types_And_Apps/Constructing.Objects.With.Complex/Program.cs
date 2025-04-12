using Constructing.Objects.With.Complex;

internal class Program
{
    static void Main(string[] args)
    {
        DeploymentService service =
            new DeploymentBuilder()
            .SetStartDelay(3000)
            .SetErrorRetries(3)
            .SetReportFormat("html")
            .Build();

        service.Start();
    }
}