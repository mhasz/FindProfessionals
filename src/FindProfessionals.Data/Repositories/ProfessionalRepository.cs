using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindProfessionals.Data.Repositories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly DataDbContext _context;

        public ProfessionalRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professional>> GetProfessionalsAsync()
        {
            return await _context.Professionals.AsNoTracking().ToListAsync();
        }

        public async Task<Professional> GetProfessionalByIdAsync(Guid id)
        {
            return await _context.Professionals.FindAsync(id);
        }

        public async Task InsertProfessionalAsync(Professional professional)
        {
            await _context.Professionals.AddAsync(professional);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfessionalAsync(Professional professional)
        {
            _context.Professionals.Update(professional);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfessionalAsync(Guid id)
        {
            _context.Professionals.Remove(new Professional { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
