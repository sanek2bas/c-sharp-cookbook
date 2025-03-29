namespace Removing.Explicit.Dependencies
{
    public sealed class DeploymentRepository
    {
        public void SaveStatus(string status)
        {
            Console.WriteLine("Saving status...");
        }
    }
}
