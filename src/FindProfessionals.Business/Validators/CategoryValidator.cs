using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;
using FluentValidation;

namespace FindProfessionals.Business.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        private readonly ICategoryService _categoryService;

        public CategoryValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50)
                .Must(_categoryService.IsNameUnique);
        }
    }
}
