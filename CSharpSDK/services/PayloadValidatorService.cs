using CSharpSDK.DTOs;
using CSharpSDK.Validators;
using FluentValidation.Results;

namespace CSharpSDK.Services
{
    public static class PayloadValidatorService
    {
        public static (bool IsValid, List<string> Errors) ValidateReceiptPayload(ReceiptDto receiptData)
        {
            var validator = new ReceiptValidator();
            ValidationResult results = validator.Validate(receiptData);
            var errors = new List<string>();
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            return (results.IsValid, errors);
        }
        public static (bool IsValid, List<string> Errors) ValidateTransactionPayload(TransactionDto transactionData)
        {
            var validator = new TransactionValidator();
            ValidationResult results = validator.Validate(transactionData);

            var errors = new List<string>();
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    errors.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            return (results.IsValid, errors);
        }
    }
}
