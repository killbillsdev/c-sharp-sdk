using FluentValidation;
using CSharpSDK.DTOs;
using System.Linq;

namespace CSharpSDK.Validators
{
    public class ReceiptValidator : AbstractValidator<ReceiptDto>
    {
        public ReceiptValidator()
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

        }
    }

    public class ReceiptDetailValidator : AbstractValidator<ReceiptDetailDto>
    {
        public ReceiptDetailValidator()
        {
            // RuleFor(x => x.ReferenceId).NotEmpty();
            // RuleFor(x => x.Amount).GreaterThan(0);
            // RuleFor(x => x.CustomerId).NotEmpty();
            // RuleFor(x => x.ReceiptDate).NotEmpty();
            // RuleFor(x => x.StoreName).NotEmpty();
            // RuleFor(x => x.BillingDescriptor).NotEmpty();
            // RuleFor(x => x.Siret)
            //     .Matches(@"^[0-9]+$")
            //     .WithMessage("Siret must be numeric.")
            //     .Length(14);
            // RuleFor(x => x.Currency);
            
            }
}
}

