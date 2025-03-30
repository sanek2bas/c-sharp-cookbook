namespace Making.Classes.Adapt.To.Your.Interface
{
    public class ThirdPartyDeploymentService
    {
        public void PerformValidation()
        {
            Console.WriteLine("3rd Party Deployment Service Validated");
        }
    }

    public class ThirdPartyDeploymentAdapter : IDeploymentService
    {
        private ThirdPartyDeploymentService service;

        public ThirdPartyDeploymentAdapter()
        {
            service = new ThirdPartyDeploymentService();
        }

        public void Validate()
        {
            service.PerformValidation();
        }
    }
}
