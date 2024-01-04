using System.Text.Json;
using CSharpSDK.DTOs;

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

        public async Task<StoreData> GetStoresAsync(string env, string apiKey, int offset, int limit)
        {
            return await _killBillsApiService.FetchStoresAsync(env, apiKey, offset, limit );
        }
    }

    public class KillBillsApiService
    {
        public async Task<StoreData> FetchStoresAsync(string env, string apiKey , int offset, int limit)
        {
            if (string.IsNullOrEmpty(env) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("No environment specified or API key provided");
            }

            string baseURL = (env == "prod")
                ? "https://w.killbills.co"
                : $"https://w.{env}.killbills.dev";

            string url = $"{baseURL}/stores?offset={offset}&limit={limit}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", apiKey);
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
                }

                string json = await response.Content.ReadAsStringAsync();
                StoreData storeItems = JsonSerializer.Deserialize<StoreData>(json);
                if (storeItems == null || storeItems.Count == 0)
                {
                  throw new InvalidOperationException("Response does not contain any items");
                }

                return storeItems;
            }
        }  
    }
  }
