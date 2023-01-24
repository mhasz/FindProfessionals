using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Validators.Document;
using FindProfessionals.Domain.Entities;
using FindProfessionals.Domain.Enums;
using FluentValidation;

namespace FindProfessionals.Business.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(50);

            RuleFor(x => x.DocumentType)
                .NotNull()
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.BirthDate)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now.AddYears(-18))
                .GreaterThan(DateTime.Now.AddYears(-100));

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .Matches("^\\(?[1-9]{2}\\)? ?(?:[2-8]|9[1-9])[0-9]{3}\\-?[0-9]{4}$").WithMessage("Phone in invalid format, please enter your number with area code.");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .Must(IsEmailUnique)
                .WithMessage("This Email is already registered.");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]*$").WithMessage("Your password must contain at least one (!? *.).");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match.");

            When(x => x.DocumentType == UserDocumentType.Personal, () =>
            {
                RuleFor(x => x.Document.Length)
                    .Equal(CpfValidation.SizeCpf)
                    .WithMessage("The Document field needs to be {ComparisonValue} characters and {PropertyValue} was provided.");

                RuleFor(x => CpfValidation.Validate(x.Document))
                    .Equal(true)
                    .WithMessage("The Document provided is invalid.");

                RuleFor(x => x.Document)
                    .Must(IsDocumentUnique)
                    .WithMessage("This Cpf is already registered.");
            });

            When(x => x.DocumentType == UserDocumentType.Company, () =>
            {
                RuleFor(x => x.Document.Length)
                    .Equal(CnpjValidation.SizeCnpj)
                    .WithMessage("The Document field needs to be {ComparisonValue} characters and {PropertyValue} was provided.");

                RuleFor(x => CnpjValidation.Validate(x.Document))
                    .Equal(true)
                    .WithMessage("The Document provided is invalid.");

                RuleFor(x => x.Document)
                    .Must(IsDocumentUnique)
                    .WithMessage("This Cnpj is already registered.");
            });
        }

        private bool IsEmailUnique(string email)
        {
            return _userRepository.GetUserByEmail(email) != null;
        }

        private bool IsDocumentUnique(string document)
        {
            return _userRepository.GetUserByDocument(document) != null;
        }
    }
}
