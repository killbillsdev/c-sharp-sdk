using Xunit;
using CSharpSDK.Services;
using CSharpSDK.DTOs;

namespace CSharpSDK.Tests
{
    public class PayloadValidatorServiceTests
    {
        [Fact]
        public void ValidateReceiptPayload_ValidPayload_ReturnsTrueWithNoErrors()
        {
            // Arrange
            var validReceiptData = new ReceiptDto
              {
               ReferenceId = "reference-id",
               Amount = 1000,
               Currency = "EUR",
               Covers = 0,
               Invoice = 1,
               Table = "21",
               Date = "2023-09-07T09:04:08",
               PartnerName = "zelty",
               Taxes = new List<Tax> {
                 new Tax {
                    Rate = 550,
                    Amount = 20
                 }
               },
               Merchant = new Merchant {
                ReferenceID = "reference-id-merchant"
               },
               Store = new Store {
                ReferenceID = "reference-id-store",
                StoreName = "super-store-name",
                BillingDescriptor = "rambutau-super-store-name-pos1",
                Siret = "12345678910101"
               },
               Items = new List<Item> {
                 new() {
                    Name = "soupe aux choux",
                    Quantity = 2,
                    Price = 200,
                    Tax = new Tax {
                    Rate = 200,
                    Amount = 20
                 }
                 }
               },
               Payments = new List<Payment> {
                    new Payment {
                        TransactionDate = "2023-09-07T09:04:08",
                        Amount = 200,
                    }
               }
            };

            // Act
            var (isValid, errors) = PayloadValidatorService.ValidateReceiptPayload(validReceiptData);

            // Assert
            Assert.True(isValid);
            Assert.Empty(errors);
        }

        [Fact]
        public void ValidateReceiptPayload_InvalidPayload_ReturnsFalseWithErrors()
        {
            // Arrange
            var invalidReceiptData = new ReceiptDto
              {
               ReferenceId = "reference-id",
               Amount = 1000,
               Currency = "UnknownCurrency",
               Covers = -0,
               Invoice = 1,
               Table = "21",
               Date = "2023-09-07T09:04:08",
               PartnerName = "zelty",
               Taxes = new List<Tax> {
                 new Tax {
                    Rate = 200,
                    Amount = 20
                 }
               },
               Merchant = new Merchant {
                ReferenceID = "reference-id-merchant"
               },
               Store = new Store {
                ReferenceID = "reference-id-store",
                StoreName = "super-store-name",
                BillingDescriptor = "rambutau-super-store-name-pos1",
                Siret = "1234"
               },
               Items = new List<Item> {
                 new() {
                    Name = "soupe aux choux",
                    Quantity = 2,
                    Price = 200,
                    Tax = new Tax {
                    Rate = 200,
                    Amount = 20
                 }
                 }
               },
               Payments = new List<Payment> {
                    new Payment {
                        TransactionDate = "2023-09-07T09:04:08",
                        Amount = 200,

                    }
               }
            };

            // Act
            var (isValid, errors) = PayloadValidatorService.ValidateReceiptPayload(invalidReceiptData);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(errors);
        }
    }
}
