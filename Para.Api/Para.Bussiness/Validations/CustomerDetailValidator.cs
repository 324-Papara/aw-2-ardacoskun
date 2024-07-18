using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validations
{
    public class CustomerDetailValidator : AbstractValidator<CustomerDetail>
    {
        public CustomerDetailValidator()
        {
            RuleFor(x => x.FatherName)
                .NotEmpty()
                .Length(2, 30)
                .WithMessage("Father name must be between 2-30 characters!");

            RuleFor(x => x.MotherName)
                .NotEmpty()
                .Length(2, 30)
                .WithMessage("Mother name must be between 2-30 characters!");

            RuleFor(x => x.MontlyIncome)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.Occupation)
                .NotEmpty()
                .Length(2, 30)
                .WithMessage("Occupation must be between 2-30 characters!");
        }
    }
}
