namespace Delegating.Object.Creation.To.Method
{
    public interface IDeploymentPlugin
    {
        bool Validate();
    }

    public class DeploymentPlugin1 : IDeploymentPlugin
    {
        public bool Validate()
        {
            Console.WriteLine("Validated Plugin 1");
            return true;
        }
    }

    public class DeploymentPlugin2 : IDeploymentPlugin
    {
        public bool Validate()
        {
            Console.WriteLine("Validated Plugin 2");
            return true;
        }
    }
}
