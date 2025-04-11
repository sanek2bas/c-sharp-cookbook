public interface ILogger
{
    Task<string> WriteAsync(string message);
}

public class ConsoleLogger : ILogger
{
    public async Task<string> WriteAsync(string message)
    {
        Console.WriteLine($"Log: {message}");
        return await Task.FromResult(message);
    }
}