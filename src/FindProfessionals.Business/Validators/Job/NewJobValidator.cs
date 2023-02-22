using FindProfessionals.Domain.Dtos.Job;
using FluentValidation;

namespace FindProfessionals.Business.Validators.Job
{
    public class NewJobValidator : AbstractValidator<NewJob>
    {
        public NewJobValidator()
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
                .IsInEnum();

            RuleFor(x => x.Priority)
                .IsInEnum();
        }
    }
}
