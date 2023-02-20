using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface ISubcategoryRepository
    {
        Task<IEnumerable<Subcategory>> GetSubcategoriesAsync();
        Task<Subcategory> GetSubcategoryByIdAsync(Guid id);
        Task<IEnumerable<Subcategory>> GetSubcategoryByName(string name);
        Task<Subcategory> InsertSubcategoryAsync(Subcategory subcategory);
        Task<Subcategory> UpdateSubcategoryAsync(Subcategory subcategory);
        Task DeleteSubcategoryAsync(Guid id);
    }
}
