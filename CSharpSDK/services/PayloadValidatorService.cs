using CSharpSDK.DTOs;
using CSharpSDK.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace CSharpSDK.Services
{
    public static class PayloadValidatorService
    {
        public static bool ValidateTransactionPayload(TransactionDto transactionData)
        {
            var validator = new TransactionValidator();
            ValidationResult results = validator.Validate(transactionData);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            return results.IsValid;
        }
    }
}
