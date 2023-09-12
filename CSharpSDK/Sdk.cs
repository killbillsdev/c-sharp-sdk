namespace CSharpSDK
{
    public partial class KillBills_Sdk
    {
        private readonly SendTransaction _sendTransaction;
        private readonly SendReceipt _sendReceipt;

        public KillBills_Sdk()
        {
            _sendTransaction = new SendTransaction();
            _sendReceipt = new SendReceipt();
        }
        public async Task<string> SendReceiptAsync(string env, object receiptData, string hmacKey)
        {
            return await _sendReceipt.SendReceiptAsync(env, receiptData, hmacKey);
        }
        public async Task<string> SendTransactionAsync(string env, object transactionData, string hmacKey)
        {
            return await _sendTransaction.SendTransactionAsync(env, transactionData, hmacKey);
        }

        // À l'avenir, vous pourriez ajouter d'autres méthodes ici
    }
}