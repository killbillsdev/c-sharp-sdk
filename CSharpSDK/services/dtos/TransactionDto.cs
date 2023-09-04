namespace CSharpSDK.DTOs
{
    public class TransactionDto
    {
        public required string BankId { get; set; }
        public required string CallbackUrl { get; set; }
        public required string ReceiptFormat { get; set; }
        public required TransactionDetailDto Transaction { get; set; }
    }

    public class TransactionDetailDto
    {
        public required string ReferenceId { get; set; }
        public decimal Amount { get; set; }
        public required string CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public required string StoreName { get; set; }
        public required string BillingDescriptor { get; set; }
        public required string Siret { get; set; }
        public required PaymentDto Payment { get; set; }
        public required string Currency { get; set; }
        public required string MerchantName { get; set; }
    }

    public class PaymentDto
    {
        public required string Bin { get; set; }
        public required string LastFour { get; set; }
        public required string AuthCode { get; set; }
        public required string Scheme { get; set; }
        public required string TransactionId { get; set; }
    }
}
