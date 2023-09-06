using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpSDK.Services
{
    public class SendDataWithHmacService
    {
        private readonly CryptoService _cryptoService;

        public SendDataWithHmacService()
        {
            _cryptoService = new CryptoService();
        }

        public async Task<string> SendDataWithHmacAsync(string env, string endpoint, object data, string hmacSignature, Func<object, (bool, List<string>)> validator)
        {
            try
            {
                if (data == null || string.IsNullOrEmpty(hmacSignature))
                {
                    throw new ArgumentException($"You have not provided Data or Hmac Signature : \n Data: {data}, \n hmacSignature: {hmacSignature}");
                }

                var (isValid, errorMessages) = validator(data);
                if (!isValid)
                {
                    string combinedErrors = string.Join("; ", errorMessages);
                    throw new ArgumentException(combinedErrors);
                }
                string payloadJson = JsonConvert.SerializeObject(data);
                string hmac = CryptoService.ComputeHMACSHA256(hmacSignature,payloadJson);

                var client = new HttpClient();
                var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");
                var url = $"https://in.{(env != "prod" ? env + "." : ".")}killbills.{(env != "prod" ? "dev" : "co")}/{endpoint}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };
                requestMessage.Headers.Add("Authorization", "hmac " + hmac);

                var response = client.SendAsync(requestMessage).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;
                
                Console.WriteLine(responseContent);
                
                return payloadJson;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

