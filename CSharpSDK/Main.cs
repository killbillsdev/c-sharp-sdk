
using CSharpSDK.DTOs;

namespace CSharpSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sdk = new KillBills_Sdk();
            Console.WriteLine("Lancement de la fonction sendReceipt...");

            string env = "dev";
            TransactionDto transactionData = new()
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
        
            string hmacKey = "unknwn";
            string result = await sdk.SendTransactionAsync(env, transactionData, hmacKey);

            Console.WriteLine($"Résultat: {result}");
        }
    }
}