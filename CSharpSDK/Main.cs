using System;
using CSharpSDK;
using System.Threading.Tasks;
using CSharpSDK.DTOs;

namespace CSharpSDK
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Lancement de la fonction sendTransaction...");

            string env = "dev";
            // object transactionData = new {};
            TransactionDto transactionData = new()
{
    BankId = "f8405dae-b77a-47cf-a54f-1262015db87d",
    PartnerName = "expensya",
    CallbackUrl = "https://localhost",
    ReceiptFormat = "pdf",
    Transaction = new TransactionDetailDto
    {
        Siret = "12345678900000",
        Amount = 111102345,
        Currency = "EUR",
        StoreName = "RESTAU TEST 0", // pos_name 
        CustomerId = "fff",
        ReferenceId = "bc851e57-27ee-452c-aacf-7253ead56f8d",
        MerchantName = "RESTAU TEST 0",
        TransactionDate = DateTimeOffset.FromUnixTimeSeconds(1693560263).DateTime,
        BillingDescriptor = "fff",
        Payment = new PaymentDto
        {
            Bin = "15353635",
            LastFour = "1530145",
            AuthCode = "27402942",
            Scheme = "VISA",
            TransactionId = "ffff1142da3a7b92d51efc5819ed49c40677a"
        }
    }
};

            string hmacKey = "hmackey";

            var sender = new SendTransaction();

            string result = await sender.SendBankingTransactionAsync(env, transactionData, hmacKey);

            Console.WriteLine($"Résultat: {result}");
        }
    }
}
