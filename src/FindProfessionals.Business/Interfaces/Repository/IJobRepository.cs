using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetJobsAsync();
        Task<Job> GetJobByIdAsync(Guid id);
        Task InsertJobAsync(Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(Guid id);
    }
}
