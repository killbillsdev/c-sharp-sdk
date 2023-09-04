using System;
using System.Text;
using System.Security.Cryptography;


namespace CSharpSDK.Services
{
    public class CryptoService
    {
        public string ComputeHMACSHA256(string payload, string secretKey)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // Convertit les bytes en string hexadécimal
        }

    }
}
