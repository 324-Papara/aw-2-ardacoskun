using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validations
{
    public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
    {
        public CustomerAddressValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty()
                .Length(2, 30)
                .WithMessage("Country must be between 2-30 characters!");

            RuleFor(x => x.City)
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("City must be between 2-50 characters!");

            RuleFor(x => x.AddressLine)
                .NotEmpty()
                .MaximumLength(250)
                .WithMessage("Address line maximum length must be 250 characters!");

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Length(5, 10)
                .WithMessage("Zip code must be between 5-10 characters!");
        }
    }
}