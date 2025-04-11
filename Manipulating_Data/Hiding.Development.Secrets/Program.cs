using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();
        string key = "CSharpCookbook:ApiKey";
        Console.WriteLine($"{key}: {config[key]}");
    }
}