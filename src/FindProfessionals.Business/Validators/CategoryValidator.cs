using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Domain.Entities;
using FluentValidation;

namespace FindProfessionals.Business.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50)
                .Must(IsNameUnique);
        }

        private bool IsNameUnique(string name)
        {
            return _categoryRepository.GetCategoryByName(name) != null;
        }
    }
}
