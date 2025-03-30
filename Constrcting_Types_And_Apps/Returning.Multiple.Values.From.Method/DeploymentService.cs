public class DeploymentService
{
    public (bool deployment, bool smokeTest, bool artifacts) 
    PrepareDeployment()
    {
        ValidationStatus status = Validate();
        (bool deployment, bool smokeTest, bool artifacts) = status;
        return (deployment, smokeTest, artifacts);
    }

    private ValidationStatus Validate()
    {
        return new ValidationStatus
        {
            Deployment = true,
            SmokeTest = true,
            Artifacts = true
        };
    }
}