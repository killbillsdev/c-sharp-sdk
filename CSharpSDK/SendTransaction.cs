using CSharpSDK.Services;

namespace CSharpSDK
{
    public class SendTransaction
    {
        private readonly SendDataWithHmacService _sendDataWithHmacService;

        public SendTransaction()
        {
            _sendDataWithHmacService = new SendDataWithHmacService();
        }

        public async Task<string> SendBankingTransactionAsync(string env, object transactionData, string hmacKey)
        {
            return await _sendDataWithHmacService.SendDataWithHmacAsync(
                env,
                "transaction",
                transactionData,
                hmacKey,
                PayloadValidator.ValidateTransactionPayload
            );
        }
    }
}
