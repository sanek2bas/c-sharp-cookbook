namespace Delegating.Object.Creation.To.Method
{
    public abstract class DeploymentManagementBase
    {
        private IDeploymentPlugin deploymentService;

        protected abstract IDeploymentPlugin CreateDeploymentService();

        public bool Validate()
        {
            deploymentService ??= CreateDeploymentService();
            return deploymentService.Validate();
        }
    }

    public sealed class DeploymentManager1 : DeploymentManagementBase
    {
        protected override IDeploymentPlugin CreateDeploymentService()
        {
            return new DeploymentPlugin1();
        }
    }

    public sealed class DeploymentManager2 : DeploymentManagementBase
    {
        protected override IDeploymentPlugin CreateDeploymentService()
        {
            return new DeploymentPlugin2();
        }
    }
}
