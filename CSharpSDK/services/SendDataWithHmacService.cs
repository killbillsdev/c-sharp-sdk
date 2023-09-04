using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSharpSDK.Services;
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

        public async Task<string> SendDataWithHmacAsync(string env, string endpoint, object data, string hmacSignature, Func<object, bool> validator)
        {
            try
            {
                if (data == null || string.IsNullOrEmpty(hmacSignature))
                {
                    throw new ArgumentException($"You have not provided Data or Hmac Signature : \n Data: {data}, \n hmacSignature: {hmacSignature}");
                }

                bool validation = validator(data);
                if (!validation)
                {
                    throw new ArgumentException("Payload validation failed.");
                }

                var jsonData = JsonConvert.SerializeObject(data);
                var hashedPayload = _cryptoService.ComputeHMACSHA256(jsonData, hmacSignature);

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"hmac {hashedPayload}");
                    
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var url = $"https://in.{(env != "prod" ? env + "." : ".")}killbills.{(env != "prod" ? "dev" : "co")}/{endpoint}";
                    var response = await httpClient.PostAsync(url, content);
                    
                    if (!response.IsSuccessStatusCode)
                    {
                        return $"Error: {response.StatusCode.ToString()}";
                    }
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
