using CSharpSDK.Services;
using CSharpSDK.DTOs;

using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace CSharpSDK
{
    public class SendTransaction
    {
        private readonly SendDataWithHmacService _sendDataWithHmacService;

        public SendTransaction()
        {
            _sendDataWithHmacService = new SendDataWithHmacService();
        }

      public (bool IsValid, List<string> Errors) ValidateTransactionPayloadAdapter(object data)
{
    var transactionDto = data as TransactionDto;
    if (transactionDto == null) return (false, new List<string> { "Invalid transaction DTO." });

    return CSharpSDK.Services.PayloadValidatorService.ValidateTransactionPayload(transactionDto);
}


        public async Task<string> SendBankingTransactionAsync(string env, object transactionData, string hmacKey)
        {
            if (transactionData == null) 
            {
                throw new ArgumentNullException(nameof(transactionData));
            } else
            {
            return await _sendDataWithHmacService.SendDataWithHmacAsync(
                env,
                "transaction",
                transactionData,
                hmacKey,
                ValidateTransactionPayloadAdapter
            );
            }
        }
    }
}
