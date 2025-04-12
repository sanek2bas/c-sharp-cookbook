namespace Constructing.Objects.With.Complex
{
    public class DeploymentBuilder
    {
        private DeploymentService service;

        public DeploymentBuilder()
        {
            service = new DeploymentService();
        }

        public DeploymentBuilder SetStartDelay(int delay)
        {
            service.StartDelay = delay;
            return this;
        }

        public DeploymentBuilder SetErrorRetries(int retries)
        {
            service.ErrorRetries = retries;
            return this;
        }

        public DeploymentBuilder SetReportFormat(string format)
        {
            service.ReportFormat = format;
            return this;
        }

        public DeploymentService Build()
        {
            return service;
        }
    }
}
