using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<bool> RemoveAsync(Guid id);

        bool IsNameUnique(string name);
    }
}
