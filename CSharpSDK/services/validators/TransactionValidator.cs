using FluentValidation;
using CSharpSDK.DTOs;
using System.Linq;

namespace CSharpSDK.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionDto>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.BankId)
                .NotEmpty()
                .Length(36);

            RuleFor(x => x.CallbackUrl)
                .NotEmpty();

            RuleFor(x => x.ReceiptFormat)
                .NotEmpty()
                .Must(value => new[] { "JSON", "PDF", "SVG", "PNG" }.Contains(value.ToUpper()))
                .WithMessage("ReceiptFormat must be one of the following: JSON, PDF, SVG, PNG.");

            RuleFor(x => x.Transaction)
                .SetValidator(new TransactionDetailValidator());
        }
    }

    public class TransactionDetailValidator : AbstractValidator<TransactionDetailDto>
    {
        public TransactionDetailValidator()
        {
            RuleFor(x => x.ReferenceId).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.TransactionDate).NotEmpty();
            RuleFor(x => x.StoreName).NotEmpty();
            RuleFor(x => x.BillingDescriptor).NotEmpty();
            RuleFor(x => x.Siret)
                .Matches(@"^[0-9]+$")
                .WithMessage("Siret must be numeric.")
                .Length(14);

            RuleFor(x => x.Payment)
                .SetValidator(new PaymentValidator());

            RuleFor(x => x.Currency);
            
            }

            public class PaymentValidator : AbstractValidator<PaymentDto>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Bin).NotEmpty();
            RuleFor(x => x.LastFour).NotEmpty();
            RuleFor(x => x.AuthCode).NotEmpty();
            RuleFor(x => x.Scheme).NotEmpty();
            RuleFor(x => x.TransactionId).NotEmpty();
        }
    }
}
}

               
