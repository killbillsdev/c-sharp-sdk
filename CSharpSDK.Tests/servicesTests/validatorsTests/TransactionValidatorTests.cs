using Xunit;
using CSharpSDK.Validators;
using CSharpSDK.DTOs;

namespace CSharpSDK.Tests
{
    public class ValidatorTests
    {
        [Fact]
        public void TransactionValidator_ValidTransaction_ReturnsValid()
        {
            var validator = new TransactionValidator();
            var validTransaction = new TransactionDto
            {
               BankId = "fbec0cb5-91c8-4b8b-a194-c018fbfe258d",
               CallbackUrl = "http://localhost",
               ReceiptFormat = "json",
               Transaction = new TransactionDetailDto {
                Amount = 1000,
                ReferenceId = "reference-id",
                Currency = "EUR",
                MerchantName = "zdazd",
                CustomerId = "fzefezf",
                StoreName = "dazdazd",
                TransactionDate = 1693384066,
                BillingDescriptor = "dazdazd",
                Siret = "12238383838383",
                Payment = new PaymentDto {
                    Bin = "12",
                    LastFour = "1212",
                    AuthCode = "1212",
                    Scheme = "121", 
                    TransactionId = "121212",
                },
               },
            };
            var result = validator.Validate(validTransaction);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void TransactionValidator_InvalidTransaction_ReturnsErrors()
        {
            var validator = new TransactionValidator();
            var invalidTransaction = new TransactionDto
           {
               BankId = "fbec0cb5-91c8-4b8b-a194-c018fbfe258d",
               CallbackUrl = "http://localhost",
               ReceiptFormat = "json",
               Transaction = new TransactionDetailDto {
                Amount = -7,
                ReferenceId = "reference-id",
                Currency = "EURs",
                MerchantName = "zdazd",
                CustomerId = "fzefezf",
                StoreName = "dazdazd",
                TransactionDate = 1693384066,
                BillingDescriptor = "dazdazd",
                Siret = "12238383838383",
                Payment = new PaymentDto {
                    Bin = "12",
                    LastFour = "1212",
                    AuthCode = "1212",
                    Scheme = "121", 
                    TransactionId = "121212",
                },
               },
            };
            var result = validator.Validate(invalidTransaction);

            Assert.False(result.IsValid);
        }
    }
}