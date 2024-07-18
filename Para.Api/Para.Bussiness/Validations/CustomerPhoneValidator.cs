using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validations
{
    public class CustomerPhoneValidator : AbstractValidator<CustomerPhone>
    {
        public CustomerPhoneValidator()
        {
            RuleFor(x => x.CountyCode)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Country code must be a minimum of 2 characters!");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Length(10, 15)
                .WithMessage("Phone number must be between 10-15 characters!");
        }
    }
}
