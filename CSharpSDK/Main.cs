using CSharpSDK.DTOs;

namespace CSharpSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Lancement de la fonction sendReceipt...");

            string env = "dev";
            ReceiptDto receiptData = new()
            {
               ReferenceId = "reference-id",
               Amount = 1000,
               Currency = "EUR",
               Covers = 0,
               Invoice = 1,
               Table = "21",
               Date = "2023-09-07T09:04:08",
               PartnerName = "unknwn",
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
 
            string hmacKey = "hmac-key";
            var sdk = new KillBills_Sdk();

            string result = await sdk.SendReceiptAsync(env, receiptData, hmacKey);

            Console.WriteLine($"Résultat: {result}");
        }
    }
}