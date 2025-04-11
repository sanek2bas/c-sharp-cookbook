using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\nPassword Hash Demo\n");

        Console.Write("What is your password? ");
        string password = Console.ReadLine();

        byte[] salt = GenerateSalt();
        
        byte[] md5Hash = GenerateMD5Hash(password, salt);
        string md5HashString = Convert.ToBase64String(md5Hash);
        Console.WriteLine($"\nMD5: {md5HashString}");
        
        byte[] sha256Hash = GenerateSha256Hash(password, salt);
        string sha256HashString = Convert.ToBase64String(sha256Hash);
        Console.WriteLine($"\nSHA256: {sha256HashString}");
    }

    private static byte[] GenerateSalt()
    {
        const int SaltLength = 64;
        byte[] salt = new byte[SaltLength];
        var rngRand = RandomNumberGenerator.Create();
        rngRand.GetBytes(salt);
        return salt;
    }

    private static byte[] GenerateMD5Hash(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPassword =
        new byte[salt.Length + passwordBytes.Length];
        using var hash = MD5.Create();;
        return hash.ComputeHash(saltedPassword);
    }
    
    private static byte[] GenerateSha256Hash(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPassword =
            new byte[salt.Length + passwordBytes.Length];
        using var hash = SHA256.Create();
        return hash.ComputeHash(saltedPassword);
    }
}