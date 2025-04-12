namespace Constructing.Objects.With.Complex
{
    public class DeploymentService
    {
        public int StartDelay { get; set; }

        public int ErrorRetries { get; set; }

        public string ReportFormat { get; set; }

        public DeploymentService()
        {
            StartDelay = 2000;
            ErrorRetries = 5;
            ReportFormat = "pdf";
        }

        public void Start()
        {
            Console.WriteLine(
                $"Deployment started with:\n" +
                $" Start Delay: {StartDelay}\n" +
                $" Error Retries: {ErrorRetries}\n" +
                $" Report Format: {ReportFormat}");
        }
    }
}
