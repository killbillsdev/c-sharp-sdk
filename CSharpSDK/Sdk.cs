namespace CSharpSDK
{
    public class KillBills_Sdk
    {
        private readonly SendTransaction _sendTransaction;

        public KillBills_Sdk()
        {
            _sendTransaction = new SendTransaction();
        }

        public async Task<string> SendTransactionAsync(string env, object transactionData, string hmacKey)
        {
            return await _sendTransaction.SendTransactionAsync(env, transactionData, hmacKey);
        }

        // À l'avenir, vous pourriez ajouter d'autres méthodes ici
    }
}
