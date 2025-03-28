using System;
using System.IO;

public class DeploymentProcess : IDisposable
{
    private readonly StreamWriter report;
    private bool disposed;

    public DeploymentProcess(string filePath)
    {
        report = new StreamWriter(filePath);
    } 

    ~DeploymentProcess()
    {
        Dispose(disposing: false);
    }
    
    public bool CheckStatus()
    {
        report.WriteLine($"{DateTime.Now} Application Deployed.");
        return true;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(!disposed)
        {
            if(disposing)
            {
                // disposal of purely managed resources goes here
            }
        }
        report?.Close();
        disposed = true;
    }
}