namespace Designing.Custom.Exception
{
    public enum ValidationFailureReason
    {
        Unknown,
        PreviousDeploymentFailed,
        SmokeTestFailed,
        MissingArtifacts
    }
}
