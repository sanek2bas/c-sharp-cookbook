namespace Making.Classes.Adapt.To.Your.Interface
{
    public interface IDeploymentService
    {
        void Validate();
    }

    public class DeploymentService1 : IDeploymentService
    {
        public void Validate()
        {
            Console.WriteLine("Deployment Service 1 Validated");
        }
    }

    public class DeploymentService2 : IDeploymentService
    {
        public void Validate()
        {
            Console.WriteLine("Deployment Service 2 Validated");
        }
    }
}
