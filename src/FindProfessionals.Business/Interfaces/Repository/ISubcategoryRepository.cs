using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface ISubcategoryRepository
    {
        Task<IEnumerable<Subcategory>> GetSubcategoriesAsync();
        Task<Subcategory> GetSubcategoryByIdAsync(Guid id);
        Subcategory GetSubcategoryByName(string name);
        Task InsertSubcategoryAsync(Subcategory subcategory);
        Task UpdateSubcategoryAsync(Subcategory subcategory);
        Task DeleteSubcategoryAsync(Guid id);
    }
}
