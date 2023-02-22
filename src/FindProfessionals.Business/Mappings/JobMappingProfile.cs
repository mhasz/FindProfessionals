using AutoMapper;
using FindProfessionals.Domain.Dtos.Job;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Mappings
{
    public class JobMappingProfile : Profile
    {
        public JobMappingProfile()
        {
            CreateMap<Job, NewJob>().ReverseMap();
            CreateMap<Job, EditJob>().ReverseMap();
            CreateMap<Job, JobDetails>().ReverseMap();
        }
    }
}