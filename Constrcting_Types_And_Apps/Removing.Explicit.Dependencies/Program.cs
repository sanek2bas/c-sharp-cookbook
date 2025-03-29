using Removing.Explicit.Dependencies;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    readonly IDeploymentService service;

    public Program(IDeploymentService service)
    {
        this.service = service;
    }

    private static void Main()
    {
        var services = new ServiceCollection();
        services.AddTransient<DeploymentArtifacts>();
        services.AddTransient<DeploymentRepository>();
        services.AddTransient<IDeploymentService, DeploymentService>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        IDeploymentService deploymentService = serviceProvider.GetRequiredService<IDeploymentService>();
        var program = new Program(deploymentService);
        program.StartDeployment();
    }

    public void StartDeployment()
    {
        service.PerformValidation();
        Console.WriteLine("Validation complete - continuing...");
    }
}