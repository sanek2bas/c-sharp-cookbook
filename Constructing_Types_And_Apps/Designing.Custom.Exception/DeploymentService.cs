namespace Designing.Custom.Exception
{
    public class DeploymentService
    {
        public void Validate()
        {
            throw new DeploymentValidationException(
                "Smoke test failed - check with qa@example.com.",
                ValidationFailureReason.SmokeTestFailed);
        }
    }
}
