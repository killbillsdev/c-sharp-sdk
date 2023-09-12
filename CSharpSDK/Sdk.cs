namespace CSharpSDK
{
    public partial class KillBills_Sdk
    {
        private readonly SendTransaction _sendTransaction;
        private readonly SendReceipt _sendReceipt;
        private readonly GetStores _getStores;

        public KillBills_Sdk()
        {
            _sendTransaction = new SendTransaction();
            _sendReceipt = new SendReceipt();
            _getStores = new GetStores();
        }
        public async Task<string> SendReceiptAsync(string env, object receiptData, string hmacKey)
        {
            return await _sendReceipt.SendReceiptAsync(env, receiptData, hmacKey);
        }
        public async Task<string> SendTransactionAsync(string env, object transactionData, string hmacKey)
        {
            return await _sendTransaction.SendTransactionAsync(env, transactionData, hmacKey);
        }
        public async Task<object> GetStoresAsync(string env,string apiKey)
        {
            return await _getStores.GetStoresAsync(env, apiKey);
        }

        // À l'avenir, vous pourriez ajouter d'autres méthodes ici
    }
}