using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindProfessionals.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataDbContext _context;

        public CategoryRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task InsertCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            _context.Categories.Remove(new Category { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
