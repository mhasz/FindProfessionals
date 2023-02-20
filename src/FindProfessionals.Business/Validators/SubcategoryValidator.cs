using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;
using FluentValidation;

namespace FindProfessionals.Business.Validators
{
    public class SubcategoryValidator : AbstractValidator<Subcategory>
    {
        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryValidator(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50)
                .Must(_subcategoryService.IsNameUnique);

            RuleFor(x => x.CostCoins)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
