public class ValidatorFactory : IValidatorFactory
{
    public ThirdPartyDeploymentService CreateDeploymentService()
    {
        return new ThirdPartyDeploymentService();
    }
}

public interface IValidatorFactory
{
    ThirdPartyDeploymentService CreateDeploymentService();
}