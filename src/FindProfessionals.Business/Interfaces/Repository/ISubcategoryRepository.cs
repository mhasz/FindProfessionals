using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface ISubcategoryRepository
    {
        Task<IEnumerable<Subcategory>> GetSubcategoriesAsync();
        Task<Subcategory> GetSubcategoryByIdAsync(Guid id);
        Task<Subcategory> InsertSubcategoryAsync(Subcategory subcategory);
        Task<Subcategory> UpdateSubcategoryAsync(Subcategory subcategory);
        Task<Subcategory> DeleteSubcategoryAsync(Guid id);
    }
}
