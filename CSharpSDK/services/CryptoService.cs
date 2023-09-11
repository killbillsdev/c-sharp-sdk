using System.Security.Cryptography;
using System.Text;

namespace CSharpSDK.Services
{
    public class CryptoService
    {
        public static string ComputeHMACSHA256(string key, string message)
    {
        var encoding = new UTF8Encoding();
        byte[] keyByte = encoding.GetBytes(key);
        byte[] messageBytes = encoding.GetBytes(message);  
        using(var hmacsha256 = new HMACSHA256(keyByte))
        {
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            return BitConverter.ToString(hashmessage).Replace("-", "").ToLower();
        }
    }

    }
}
