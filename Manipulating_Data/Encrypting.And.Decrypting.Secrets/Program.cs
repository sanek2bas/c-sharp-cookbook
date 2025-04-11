using Encrypting.And.Decrypting.Secrets;
using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        var crypto = new Crypto();
        Console.Write("Please enter text to encrypt: ");
        string userPlainText = Console.ReadLine();
        byte[] key = GenerateKey();
        byte[] cypherBytes = crypto.Encrypt(userPlainText, key);
        string cypherText = Convert.ToBase64String(cypherBytes);
        Console.WriteLine($"Cypher Text: {cypherText}");
        string decryptedPlainText = crypto.Decrypt(cypherBytes, key);
        Console.WriteLine($"Plain Text: {decryptedPlainText}");
    }

    private static byte[] GenerateKey()
    {
        const int KeyLength = 32;
        byte[] key = new byte[KeyLength];
        var rngRand = RandomNumberGenerator.Create();
        rngRand.GetBytes(key);
        return key;
    }
}