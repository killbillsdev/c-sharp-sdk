using FluentValidation;
using CSharpSDK.DTOs;

namespace CSharpSDK.Validators
{
    public class ReceiptValidator : AbstractValidator<ReceiptDto>
    {
        public ReceiptValidator()
        {
            RuleFor(x => x.ReferenceId).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TotalTaxAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Currency).NotEmpty().Must(value => new[] { "EUR", "USD" }.Contains(value.ToUpper()));
            RuleFor(x => x.Date).NotEmpty().Matches(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$");
            RuleFor(x => x.Covers).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Invoice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.TotalDiscount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PartnerName).NotEmpty();

            RuleFor(x => x.Merchant).SetValidator(new MerchantValidator());
            RuleFor(x => x.Store).SetValidator(new StoreValidator());

            RuleForEach(x => x.Taxes).SetValidator(new TaxValidator());
            RuleForEach(x => x.Items).SetValidator(new ItemValidator());
            RuleForEach(x => x.Payments).SetValidator(new PaymentValidator());
        }
    }

    public class MerchantValidator : AbstractValidator<Merchant?>
    {
        public MerchantValidator()
        {
            // RuleFor(x => x.MerchantName).NotEmpty();
            // RuleFor(x => x.ReferenceID).NotEmpty();
            // RuleFor(x => x.MerchantID).GreaterThanOrEqualTo(0); // Assuming a non-negative value
        }
    }

    public class StoreValidator : AbstractValidator<Store?>
    {
        public StoreValidator()
        {
            // RuleFor(x => x.StoreName).NotEmpty();
            // RuleFor(x => x.ReferenceID).NotEmpty();
            // RuleFor(x => x.BillingDescriptor).NotEmpty();
            // RuleFor(x => x.Siret).NotEmpty().Length(14).Matches(@"^[0-9]+$");
            // RuleFor(x => x.CodeAPE).NotEmpty();
            // RuleFor(x => x.TVAIntra).NotEmpty();
            // RuleFor(x => x.Address).SetValidator(new AddressValidator());
        }
    }

    public class AddressValidator : AbstractValidator<Address?>
    {
        public AddressValidator()
        {
            // RuleFor(x => x.PostalCode).NotEmpty().GreaterThan(0);
            // RuleFor(x => x.StreetAddress).NotEmpty();
            // RuleFor(x => x.Country).NotEmpty();
            // RuleFor(x => x.City).NotEmpty();
            // RuleFor(x => x.FullAddress).NotEmpty();
            // RuleFor(x => x.Number).GreaterThanOrEqualTo(0); // Assuming a non-negative value
        }
    }

    public class TaxValidator : AbstractValidator<Tax?>
    {
        public TaxValidator()
        {
            // RuleFor(x => x.Description).NotEmpty();
            // RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
            // RuleFor(x => x.Rate).NotEmpty().Must(value => new[] { 550, 1000, 2000 }.Contains(value));
        }
    }

    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(0); // Assuming a non-negative value
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleForEach(x => x.SubItems).SetValidator(new SubItemValidator());
        }
    }

    public class SubItemValidator : AbstractValidator<SubItem>
    {
        public SubItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty(); 
            RuleFor(x => x.Tax).SetValidator(new TaxValidator());
        }
    }

    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.TransactionDate).NotEmpty().Matches(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$");
        }
    }
}
