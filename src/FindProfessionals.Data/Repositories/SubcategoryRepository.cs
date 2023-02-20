using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindProfessionals.Data.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly DataDbContext _context;

        public SubcategoryRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoriesAsync()
        {
            return await _context.Subcategories.AsNoTracking().ToListAsync();
        }

        public async Task<Subcategory> GetSubcategoryByIdAsync(Guid id)
        {
            return await _context.Subcategories.FindAsync(id);
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoryByName(string name)
        {
            return await _context.Subcategories.AsNoTracking().Where(x => x.Name.ToLower() == name.ToLower()).ToListAsync();
        }

        public async Task<Subcategory> InsertSubcategoryAsync(Subcategory subcategory)
        {
            await _context.AddAsync(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task<Subcategory> UpdateSubcategoryAsync(Subcategory subcategory)
        {
            _context.Subcategories.Update(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task DeleteSubcategoryAsync(Guid id)
        {
            var subcategory = await _context.Subcategories.FindAsync(id);
            _context.Subcategories.Remove(subcategory);
            await _context.SaveChangesAsync();
        }
    }
}
