using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CSharpSDK.DTOs;

 public class StoreData {
          [JsonPropertyName("items")]
          public List<StoreItem> Items {get; set;}
          [JsonPropertyName("count")]
          public double Count {get; set;}
};
public class StoreItem
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("billing_descriptor")]
    public string BillingDescriptor { get; set; }

    [JsonPropertyName("store_name")]
    public string StoreName { get; set; }

    [JsonPropertyName("merchant_name")]
    public string MerchantName { get; set; }

    [JsonPropertyName("full_address")]
    public string FullAddress { get; set; }

    [JsonPropertyName("siret")]
    public string Siret { get; set; }
}
