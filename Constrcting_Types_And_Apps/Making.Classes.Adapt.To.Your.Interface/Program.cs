using Making.Classes.Adapt.To.Your.Interface;

internal class Program
{
    static void Main()
    {
        new Program().Start();
    }

    public void Start()
    {
        List<IDeploymentService> services = Configure();
        foreach (var svc in services)
            svc.Validate();
    }

    private List<IDeploymentService> Configure()
    {
        return new List<IDeploymentService>
        {
            new DeploymentService1(),
            new DeploymentService2(),
            new ThirdPartyDeploymentAdapter()
        };
    }
}