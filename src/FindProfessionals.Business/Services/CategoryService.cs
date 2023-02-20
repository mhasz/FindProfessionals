using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            return await categoryRepository.InsertCategoryAsync(category);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            return await categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await categoryRepository.DeleteCategoryAsync(id);
            return true;
        }

        public bool IsNameUnique(string name)
        {
            return !categoryRepository.GetCategoryByName(name).Result.Any();
        }
    }
}
