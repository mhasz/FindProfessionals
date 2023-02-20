using AutoMapper;
using FindProfessionals.Domain.Dtos.Address;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Mappings
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
