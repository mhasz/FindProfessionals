using AutoMapper;
using FindProfessionals.Domain.Dtos.User;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Client, NewUser>().ReverseMap();
            CreateMap<Client, UserDetails>().ReverseMap();
        }
    }
}
