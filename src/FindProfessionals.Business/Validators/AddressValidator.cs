using FindProfessionals.Domain.Entities;
using FluentValidation;

namespace FindProfessionals.Business.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.AddressName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(100);

            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.State)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.City)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(x => x.PostalCode)
                .NotNull()
                .NotEmpty()
                .Matches("^[0-9]{5}-[0-9]{3}$").WithMessage("Postal code in invalid format.");
        }
    }
}
