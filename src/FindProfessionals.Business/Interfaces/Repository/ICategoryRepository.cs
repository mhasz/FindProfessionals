using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task InsertCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid id);
    }
}
