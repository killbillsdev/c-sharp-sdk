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
            ReceiptDto receiptData = new()
{
    BankId = "f8405dae-b77a-47cf-a54f-1262015db87d",
    PartnerName = "expensya",
    CallbackUrl = "https://localhost",
    ReceiptFormat = "pdf",
    Receipt = new ReceiptDetailDto
    {
        PartnerName = "test",
        BankId = "f8405da",
        CallbackUrl = "https://localhost",
        ReceiptFormat = "pdf",
       
    }
};

            string hmacKey = "hmackey";

            var sender = new SendReceipt();

            string result = await sender.SendReceiptAsync(env, receiptData, hmacKey);

            Console.WriteLine($"Résultat: {result}");
        }
    }
}