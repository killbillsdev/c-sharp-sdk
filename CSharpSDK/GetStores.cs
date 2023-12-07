using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpSDK
{
  public partial class Killbills_sdk
  {
    public class StoreData
{
    public List<object> Items { get; set; }
}
    public async Task<List<object>> GetStores(string env, string apiKey, int offset, int limit)
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
        Console.WriteLine("Lancement de la fonction sendReceipt...",json);

        // Parse the JSON response
        StoreData data = Newtonsoft.Json.JsonConvert.DeserializeObject<StoreData>(json);

        if (data == null || data.Items == null)
        {
          throw new InvalidOperationException("Response does not contain 'items'");
        }
        Console.WriteLine("Lancement de la fonction sendReceipt...",data);
        return data.Items;
      }
    }
  }
}