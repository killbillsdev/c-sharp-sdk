namespace CSharpSDK
{
    public class KillBills_Sdk
    {
        private readonly SendReceipt _sendReceipt;

        public KillBills_Sdk()
        {
            _sendReceipt = new SendReceipt();
        }

        public async Task<string> SendReceiptAsync(string env, object receiptData, string hmacKey)
        {
            return await _sendReceipt.SendReceiptAsync(env, receiptData, hmacKey);
        }
    }
}