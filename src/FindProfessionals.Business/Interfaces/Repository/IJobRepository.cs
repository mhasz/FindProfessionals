using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetJobsAsync();
        Task<Job> GetJobByIdAsync(Guid id);
        Task<Job> InsertJobAsync(Job job);
        Task<Job> UpdateJobAsync(Job job);
        Task<Job> DeleteJobAsync(Guid id);
    }
}
