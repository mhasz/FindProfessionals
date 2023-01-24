using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Domain.Entities;
using FluentValidation;

namespace FindProfessionals.Business.Validators
{
    public class SubcategoryValidator : AbstractValidator<Subcategory>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;

        public SubcategoryValidator(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50)
                .Must(IsNameUnique);

            RuleFor(x => x.CostCoins)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }

        private bool IsNameUnique(string name)
        {
            return _subcategoryRepository.GetSubcategoryByName(name) != null;
        }
    }
}
