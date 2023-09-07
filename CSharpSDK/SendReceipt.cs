using CSharpSDK.Services;
using CSharpSDK.DTOs;

using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace CSharpSDK
{
    public class SendReceipt
    {
        private readonly SendDataWithHmacService _sendDataWithHmacService;

        public SendReceipt()
        {
            _sendDataWithHmacService = new SendDataWithHmacService();
        }

      public (bool IsValid, List<string> Errors) ValidateReceiptPayloadAdapter(object data)
{
    var receiptDto = data as ReceiptDto;
    if (receiptDto == null) return (false, new List<string> { "Invalid receipt DTO." });

    return CSharpSDK.Services.PayloadValidatorService.ValidateReceiptPayload(receiptDto);
}


        public async Task<string> SendReceiptAsync(string env, object receiptData, string hmacKey)
        {
            if (receiptData == null) 
            {
                throw new ArgumentNullException(nameof(receiptData));
            } else
            {
            return await _sendDataWithHmacService.SendDataWithHmacAsync(
                env,
                "receipt",
                receiptData,
                hmacKey,
                ValidateReceiptPayloadAdapter
            );
            }
        }
    }
}