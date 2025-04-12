namespace Designing.Custom.Exception
{
    [Serializable]
    public class DeploymentValidationException : System.Exception
    {
        public ValidationFailureReason Reason { get; set; }

        public DeploymentValidationException() :
            this("Validation Failed!", null, ValidationFailureReason.Unknown)
        {
        }

        public DeploymentValidationException(string message) :
            this(message, null, ValidationFailureReason.Unknown)
        {
        }

        public DeploymentValidationException(string message, 
                                             System.Exception innerException) :
            this(message, innerException, ValidationFailureReason.Unknown)
        {
        }

        public DeploymentValidationException(string message, 
                                             ValidationFailureReason reason) : 
            this(message, null, reason)
        {
        }

        public DeploymentValidationException(string message,
                                             System.Exception innerException,
                                             ValidationFailureReason reason) :
            base(message, innerException)
        {
            Reason = reason;
        }

        public override string ToString()
        {
            return
            base.ToString() +
            $" - Reason: {Reason} ";
        }
    }
}
