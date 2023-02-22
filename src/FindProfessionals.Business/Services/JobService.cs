using AutoMapper;
using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Dtos.Job;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public JobService(IJobRepository jobRepository, IClientRepository clientRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<JobDetails>> GetAsync()
        {
            return mapper.Map<List<JobDetails>>(await jobRepository.GetJobsAsync());
        }

        public async Task<JobDetails> GetByIdAsync(Guid id)
        {
            return mapper.Map<JobDetails>(await jobRepository.GetJobByIdAsync(id));
        }

        public async Task<JobDetails> AddAsync(NewJob newJob, Guid userId)
        {
            var job = mapper.Map<Job>(newJob);
            var client = await clientRepository.GetClientByUserLogged(userId);

            job.ClientId = client.Id;
            job.Published = DateTime.UtcNow;
            job.Active = true;

            return mapper.Map<JobDetails>(await jobRepository.InsertJobAsync(job));
        }

        public async Task<JobDetails> UpdateAsync(EditJob editJob)
        {
            var job = await jobRepository.GetJobByIdAsync(editJob.Id);

            job = mapper.Map(editJob, job);
            job.LastUpdate= DateTime.UtcNow;

            return mapper.Map<JobDetails>(await jobRepository.UpdateJobAsync(job));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await jobRepository.DeleteJobAsync(id);
            return true;
        }
    }
}