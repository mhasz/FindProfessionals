using FindProfessionals.Domain.Entities;
using FluentValidation;

namespace FindProfessionals.Business.Validators
{
    public class ProfessionalValidator : AbstractValidator<Professional>
    {
        public ProfessionalValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(50);

            RuleFor(x => x.About)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(500);
        }
    }
}
