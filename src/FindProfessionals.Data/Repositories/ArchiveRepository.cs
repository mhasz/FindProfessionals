using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindProfessionals.Data.Repositories
{
    public class ArchiveRepository : IArchiveRepository
    {
        private readonly DataDbContext _context;

        public ArchiveRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Archive> GetArchiveByIdAsync(Guid id)
        {
            return await _context.Archives.FindAsync(id);
        }

        public async Task<IEnumerable<Archive>> GetArchivesByJobIdAsync(Guid id)
        {
            return await _context.Archives.AsNoTracking().Where(a => a.JobId == id).ToListAsync();
        }

        public async Task InsertArchiveAsync(Archive archive)
        {
            await _context.Archives.AddAsync(archive);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArchiveAsync(Guid id)
        {
            _context.Archives.Remove(new Archive { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
