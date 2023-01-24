using FindProfessionals.Domain.Entities;
using FluentValidation;

namespace FindProfessionals.Business.Validators
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(1000);

            RuleFor(x => x.Type)
                .NotNull()
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.Priority)
                .NotNull()
                .NotEmpty()
                .IsInEnum();
        }
    }
}
