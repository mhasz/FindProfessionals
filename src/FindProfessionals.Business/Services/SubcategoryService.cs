using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Services
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository subcategoryRepository;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository)
        {
            this.subcategoryRepository = subcategoryRepository;
        }

        public async Task<IEnumerable<Subcategory>> GetAsync()
        {
            return await subcategoryRepository.GetSubcategoriesAsync();
        }

        public async Task<Subcategory> GetByIdAsync(Guid id)
        {
            return await subcategoryRepository.GetSubcategoryByIdAsync(id);
        }

        public async Task<Subcategory> AddAsync(Subcategory subcategory)
        {
            return await subcategoryRepository.InsertSubcategoryAsync(subcategory);
        }

        public async Task<Subcategory> UpdateAsync(Subcategory subcategory)
        {
            return await subcategoryRepository.UpdateSubcategoryAsync(subcategory);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await subcategoryRepository.DeleteSubcategoryAsync(id);
            return true;
        }

        public bool IsNameUnique(string name)
        {
            return !subcategoryRepository.GetSubcategoryByName(name).Result.Any();
        }
    }
}
