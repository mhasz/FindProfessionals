using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface ISubcategoryService
    {
        Task<IEnumerable<Subcategory>> GetAsync();
        Task<Subcategory> GetByIdAsync(Guid id);
        Task<Subcategory> AddAsync(Subcategory category);
        Task<Subcategory> UpdateAsync(Subcategory category);
        Task<bool> RemoveAsync(Guid id);

        bool IsNameUnique(string name);
    }
}
