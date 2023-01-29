using AutoMapper;
using FindProfessionals.Domain.Dtos.User;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, NewUser>().ReverseMap();
            CreateMap<User, EditUser>().ReverseMap();
            CreateMap<User, UserDetails>().ReverseMap();
        }
    }
}
