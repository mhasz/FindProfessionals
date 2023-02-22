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

        public async Task<Job> InsertJobAsync(Job job)
        {
            await _context.AddAsync(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job> UpdateJobAsync(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task DeleteJobAsync(Guid id)
        {
            var job = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
        }
    }
}