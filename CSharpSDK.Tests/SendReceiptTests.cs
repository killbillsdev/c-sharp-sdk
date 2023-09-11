// using Xunit;
// using Moq;
// using CSharpSDK.Services;
// using CSharpSDK.DTOs;
// using CSharpSDK;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// public class SendReceiptTests
// {
//     [Fact]
//     public async Task SendReceiptAsync_ValidReceiptData_CallsSendDataWithHmacAsync()
//     {
//         // Arrange
//         var mockService = new Mock<SendDataWithHmacService>();
//         var sendReceipt = new SendReceipt(mockService.Object);
//         var receiptData = new ReceiptDto {
//             ReferenceId = "",
//             Amount = 1000,
//             Currency = "USD",
//             Date = "2023-09-07T09:04:08",
//             PartnerName = "test",
//             Merchant = new Merchant {
//                 ReferenceID = ""
//             },
//             Store = new Store {
//                 StoreName = "test",
//                 ReferenceID = "test",
//                 BillingDescriptor = "test",
//                 Siret = "12222"
//             },
//             Items = new List<Item> {
//                 new Item {
//                     Name = "test",
//                     Quantity = 1,
//                     Price = 123,
//                     Tax = new Tax {
//                         Amount = 100,
//                         Rate = 20
//                     }
//                 }
//             },
//             Payments = new List<Payment> {
//                 new Payment {
//                     Amount = "0",
//                     TransactionDate = "2023-09-07T09:04:08"
//                 }
//             }
//         }; // Supposons que vous avez déjà défini cela dans votre DTOs.
//         var hmacKey = "testHmacKey";
//         var env = "test";

//         mockService
//             .Setup(s => s.SendDataWithHmacAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>(), It.IsAny<Func<object, (bool, List<string>)>>()))
//             .ReturnsAsync("Mock Response")
//             .Verifiable();

//         // Act
//         var result = await sendReceipt.SendReceiptAsync(env, receiptData, hmacKey);

//         // Assert
//         mockService.Verify();  // Vérifie si SendDataWithHmacAsync a été appelé.
//         Assert.Equal("Mock Response", result); // ou toute autre assertion que vous souhaitez effectuer sur le résultat.
//     }
// }
