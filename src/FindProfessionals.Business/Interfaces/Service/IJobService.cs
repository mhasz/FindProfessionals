using FindProfessionals.Domain.Dtos.Job;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface IJobService
    {
        Task<IEnumerable<JobDetails>> GetAsync();
        Task<JobDetails> GetByIdAsync(Guid id);
        Task<JobDetails> AddAsync(NewJob newJob, Guid userId);
        Task<JobDetails> UpdateAsync(EditJob editJob);
        Task<bool> RemoveAsync(Guid id);
    }
}
