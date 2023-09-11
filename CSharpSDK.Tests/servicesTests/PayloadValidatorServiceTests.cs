using Xunit;
using CSharpSDK.Services;
using CSharpSDK.DTOs;

namespace CSharpSDK.Tests
{
    public class PayloadValidatorServiceTests
    {
        [Fact]
        public void ValidateTransactionPayload_ValidPayload_ReturnsTrueWithNoErrors()
        {
            // Arrange
            var validTransactionData = new TransactionDto
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

            // Act
            var (isValid, errors) = PayloadValidatorService.ValidateTransactionPayload(validTransactionData);

            // Assert
            Assert.True(isValid);
            Assert.Empty(errors);
        }

        [Fact]
        public void ValidateTransactionPayload_InvalidPayload_ReturnsFalseWithErrors()
        {
            // Arrange
            var invalidTransactionData = new TransactionDto
              {
               BankId = "fbec0cb5-91c8-4b8b-a194-c018fbfe258d",
               CallbackUrl = "http://localhost",
               ReceiptFormat = "json",
               Transaction = new TransactionDetailDto {
                Amount = 0,
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

            // Act
            var (isValid, errors) = PayloadValidatorService.ValidateTransactionPayload(invalidTransactionData);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(errors);
        }
    }
}