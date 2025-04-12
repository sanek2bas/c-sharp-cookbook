internal class Program
{
    readonly DeploymentService deployment;

    public Program()
    {
        deployment = new DeploymentService();
    }

    static void Main()
    {
        new Program().Start();
    }

    void Start()
    {
        (bool deployed, bool smokeTest, bool artifacts) =
            deployment.PrepareDeployment();
        
        Console.WriteLine(
            $"\nDeployment Status:\n\n" +
            $"Is Previous Deployment Complete? {deployed}\n" +
            $"Is Previous Smoke Test Complete? {smokeTest}\n" +
            $"Are artifacts for this deployment ready? {artifacts}\n\n" +
            $"Can deploy: {deployed && smokeTest && artifacts}");
    }
}