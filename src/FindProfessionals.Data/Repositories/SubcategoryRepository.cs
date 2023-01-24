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

        public Subcategory GetSubcategoryByName(string name)
        {
            return _context.Subcategories.AsNoTracking().Where(x => x.Name.ToLower() == name.ToLower()).SingleOrDefault();
        }

        public async Task InsertSubcategoryAsync(Subcategory subcategory)
        {
            await _context.AddAsync(subcategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubcategoryAsync(Subcategory subcategory)
        {
            _context.Subcategories.Update(subcategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubcategoryAsync(Guid id)
        {
            _context.Subcategories.Remove(new Subcategory { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
