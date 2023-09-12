using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpSDK
{
    public class GetStores
    {
        private readonly KillBillsApiService _killBillsApiService;

        public GetStores() : this(new KillBillsApiService())
        {
        }

        public GetStores(KillBillsApiService killBillsApiService)
        {
            _killBillsApiService = killBillsApiService ?? throw new ArgumentNullException(nameof(killBillsApiService));
        }

        public async Task<List<object>> GetStoresAsync(string env, string apiKey)
        {
            return await _killBillsApiService.FetchStoresAsync(env, apiKey);
        }
    }

    public class KillBillsApiService
    {
        public async Task<List<object>> FetchStoresAsync(string env, string apiKey)
        {
            if (string.IsNullOrEmpty(env) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("No environment specified or API key provided");
            }

            string baseURL = (env == "prod")
                ? "https://w.killbills.co"
                : $"https://w.{env}.killbills.dev";

            string url = $"{baseURL}/stores";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", apiKey);
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
                }

                string json = await response.Content.ReadAsStringAsync();

                StoreData data = Newtonsoft.Json.JsonConvert.DeserializeObject<StoreData>(json);

                if (data == null || data.Items == null)
                {
                    throw new InvalidOperationException("Response does not contain 'items'");
                }

                return data.Items;
            }
        }

        public class StoreData
        {
            public List<object>? Items { get; set; }
        }
    }
}
