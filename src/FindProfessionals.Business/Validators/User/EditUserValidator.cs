using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Business.Validators.User.Document;
using FindProfessionals.Domain.Dtos.User;
using FindProfessionals.Domain.Enums;
using FluentValidation;

namespace FindProfessionals.Business.Validators.User
{
    public class EditUserValidator : AbstractValidator<EditUser>
    {
        private readonly IUserService _userService;

        public EditUserValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .Matches("^\\(?[1-9]{2}\\)? ?(?:[2-8]|9[1-9])[0-9]{3}\\-?[0-9]{4}$").WithMessage("Phone in invalid format, please enter your number with area code.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .Must(_userService.IsEmailUniqueEdit)
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
        }
    }
}
