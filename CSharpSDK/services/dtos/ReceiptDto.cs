using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CSharpSDK.DTOs
{
    public class ReceiptDto
    {
     
        [Required]
        [JsonPropertyName("reference_id")]
        public required string ReferenceId { get; set; }

        [Required]
        [JsonPropertyName("amount")]
        public required double Amount { get; set; }

        [JsonPropertyName("total_tax_amount")]
        public double TotalTaxAmount { get; set; }

        [Required]
        [JsonPropertyName("currency")]
        [RegularExpression(@"(EUR|USD)", ErrorMessage = "Invalid currency")]
        public required string Currency { get; set; }

        [Required]
        [JsonPropertyName("date")]
        public required string Date { get; set; }

        [JsonPropertyName("covers")]
        public int Covers { get; set; }

        [JsonPropertyName("table")]
        public string? Table { get; set; }

        [JsonPropertyName("invoice")]
        public int Invoice { get; set; }

        [JsonPropertyName("total_discount")]
        public double TotalDiscount { get; set; }

        [JsonPropertyName("mode")]
        public string? Mode { get; set; }

        [Required]
        [JsonPropertyName("partner_name")]
        public required string PartnerName { get; set; }

        [Required]
        [JsonPropertyName("merchant")]
        public required Merchant Merchant { get; set; } // Assurez-vous d'avoir également converti cette classe en C#

        [Required]
        [JsonPropertyName("store")]
        public required Store Store { get; set; } // De même pour celle-ci

        [JsonPropertyName("taxes")]
        public List<Tax>? Taxes { get; set; } // Et pour celle-ci

        [Required]
        [JsonPropertyName("items")]
        public required List<Item> Items { get; set; } // Et enfin pour celle-ci

        [Required]
        [JsonPropertyName("payments")]
        public required List<Payment> Payments { get; set; } // Et celle-ci        
    }

public class Payment
{
    [JsonPropertyName("bin")]
    public string? Bin { get; set; }

    [JsonPropertyName("scheme")]
    public string? Scheme { get; set; }

    [JsonPropertyName("lastFour")]
    public string? LastFour { get; set; }

    [JsonPropertyName("auth_code")]
    public string? AuthCode { get; set; }

    [JsonPropertyName("transaction_id")]
    public string? TransactionID { get; set; }

    [Required]
    [JsonPropertyName("amount")]
    public required  string Amount { get; set; }


    [JsonPropertyName("transaction_date")]
    public required string TransactionDate { get; set; }


    [JsonPropertyName("payment_type")]
    public string? PaymentType { get; set; }
}


public class Merchant
{
    [JsonPropertyName("merchant_name")]
    public string? MerchantName { get; set; }

    [Required]
    [JsonPropertyName("reference_id")]
    public required string ReferenceID { get; set; }

    [JsonPropertyName("merchant_id")]
    public int MerchantID { get; set; }
}

public class Store
{
    [Required]
    [JsonPropertyName("store_name")]
    public required string StoreName { get; set; }

    [Required]
    [JsonPropertyName("reference_id")]
    public required string ReferenceID { get; set; }

    [Required]
    [JsonPropertyName("billing_descriptor")]
    public required string BillingDescriptor { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 14)]
    [JsonPropertyName("siret")]
    public required string Siret { get; set; }

    [JsonPropertyName("code_ape")]
    public string? CodeAPE { get; set; }

    [JsonPropertyName("tva_intra")]
    public string? TVAIntra { get; set; }

    [Required]
    [JsonPropertyName("address")]
    public Address? Address { get; set; }
}

public class Address
{
    [Required]
    [JsonPropertyName("postal_code")]
    public int PostalCode { get; set; }

    [JsonPropertyName("street_address")]
    public string? StreetAddress { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("full_address")]
    public string? FullAddress { get; set; }

    [JsonPropertyName("number")]
    public int Number { get; set; }
}

public class Tax
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [Required]
    [JsonPropertyName("amount")]
    public required double Amount { get; set; }

    [Required]
    [RegularExpression(@"(550|1000|2000)", ErrorMessage = "Invalid rate")]
    [JsonPropertyName("rate")]
    public required int Rate { get; set; }
}

public class Item
{
    [JsonPropertyName("reference_id")]
    public string? ReferenceID { get; set; }

    [Required]
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [Required]
    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }

    [Required]
    [JsonPropertyName("price")]
    public required double Price { get; set; }

    [JsonPropertyName("discount")]
    public double Discount { get; set; }

    [JsonPropertyName("total_amount")]
    public double TotalAmount { get; set; }

    [Required]
    [JsonPropertyName("tax")]
    public required Tax Tax { get; set; }

    [JsonPropertyName("subitems")]
    public List<SubItem>? SubItems { get; set; }
}

public class SubItem
{
    [JsonPropertyName("reference_id")]
    public string? ReferenceID { get; set; }

    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("discount")]
    public double Discount { get; set; }

    [JsonPropertyName("total_amount")]
    public double TotalAmount { get; set; }

    [JsonPropertyName("tax")]
    public Tax? Tax { get; set; }
}
}