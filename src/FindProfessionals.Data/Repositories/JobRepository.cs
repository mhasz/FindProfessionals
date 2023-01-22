using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindProfessionals.Data.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly DataDbContext _context;

        public JobRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await _context.Jobs.AsNoTracking().ToListAsync();
        }

        public async Task<Job> GetJobByIdAsync(Guid id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task InsertJobAsync(Job job)
        {
            await _context.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(Guid id)
        {
            _context.Jobs.Remove(new Job { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
