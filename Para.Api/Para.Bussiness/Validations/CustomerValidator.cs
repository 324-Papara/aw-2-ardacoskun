using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validations;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(2, 20)
            .WithMessage("First name length must be between 2-20 characters!");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(2, 20)
            .WithMessage("Last name length must be between 2-20 characters!");

        RuleFor(x => x.IdentityNumber)
            .NotEmpty()
            .Length(11)
            .WithMessage("Identity number must be 11 characters!");

        RuleFor(x => x.Email)
            .NotEmpty()
            .Length(10, 150)
            .WithMessage("Email must be between 10-150 characters!");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .LessThan(DateTime.Now)
            .WithMessage("Date of birth must be a past date!");

        RuleFor(x => x.CustomerNumber)
            .NotEmpty()
            .InclusiveBetween(1, 10000)
            .WithMessage("Customer number must be between 1-100000");
    }
}
