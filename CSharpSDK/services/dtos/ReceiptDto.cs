using System;

namespace CSharpSDK.DTOs
{
    public class ReceiptDto
    {
        public required string PartnerName { get; set; }
        public required string BankId { get; set; }
        public required string CallbackUrl { get; set; }
        public required string ReceiptFormat { get; set; }
        public required ReceiptDetailDto Receipt { get; set; }
    }
    public class ReceiptDetailDto
    {
        public required string PartnerName { get; set; }
        public required string BankId { get; set; }
        public required string CallbackUrl { get; set; }
        public required string ReceiptFormat { get; set; }
    }
}