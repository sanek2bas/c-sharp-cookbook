using Delegating.Object.Creation.To.Method;

internal class Program
{
    readonly DeploymentManagementBase[] deploymentManagers;

    public Program(DeploymentManagementBase[] deploymentManagers)
    {
        this.deploymentManagers = deploymentManagers;
    }

    static void Main(string[] args)
    {
        DeploymentManagementBase[] deploymentManagers = GetPlugins();
        var program = new Program(deploymentManagers);
        program.Run();
    }

    static DeploymentManagementBase[] GetPlugins()
    {
        return new DeploymentManagementBase[]
        {
            new DeploymentManager1(),
            new DeploymentManager2()
        };
    }

    void Run()
    {
        foreach (var manager in deploymentManagers)
            manager.Validate();
    }
}