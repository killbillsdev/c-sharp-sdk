using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CSharpSDK.DTOs
{
    public class TransactionDto
    {
        [Required]
        [JsonPropertyName("bank_id")]
        public required string BankId { get; set; }
        [Required]
        [JsonPropertyName("callback_url")]
        public required string CallbackUrl { get; set; }
        [Required]
        [JsonPropertyName("receipt_format")]
        public required string ReceiptFormat { get; set; }
        [Required]
        [JsonPropertyName("transaction")]
        public required TransactionDetailDto Transaction { get; set; }
    }

    public class TransactionDetailDto
    {
        [Required]
        [JsonPropertyName("reference_id")]
        public required string ReferenceId { get; set; }

        [Required]
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("customer_id")]
        public required string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("transaction_date")]
        public required double TransactionDate { get; set; }

        [Required]
        [JsonPropertyName("store_name")]
        public required string StoreName { get; set; }

        [Required]
        [JsonPropertyName("billing_descriptor")]
        public required string BillingDescriptor { get; set; }

        [Required]
        [JsonPropertyName("siret")]
        public required string Siret { get; set; }

        [Required]
        [JsonPropertyName("payment")]
        public required PaymentDto Payment { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("merchant_name")]
        public string? MerchantName { get; set; }

        [JsonPropertyName("merchant_id")]
        public string? MerchantId { get; set; }
    }

    public class PaymentDto
    {
        [Required]
        [JsonPropertyName("bin")]
        public required string Bin { get; set; }
        [Required]
        [JsonPropertyName("last_four")]
        public required string LastFour { get; set; }
        [Required]
        [JsonPropertyName("auth_code")]
        public required string AuthCode { get; set; }
        [Required]
        [JsonPropertyName("scheme")]
        public required string Scheme { get; set; }
        [Required]
        [JsonPropertyName("transaction_id")]
        public required string TransactionId { get; set; }
        
        public static implicit operator PaymentDto(string v)
        {
            throw new NotImplementedException();
        }
    }
}
