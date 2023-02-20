using AutoMapper;
using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Dtos.Address;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        public async Task<AddressDto> GetByIdAsync(Guid id)
        {
            return mapper.Map<AddressDto>(await addressRepository.GetAddressByIdAsync(id));
        }

        public async Task<AddressDto> AddAsync(AddressDto addressDto, Guid userId)
        {
            var address = mapper.Map<Address>(addressDto);
            address.UserId = userId;

            return mapper.Map<AddressDto>(await addressRepository.InsertAddressAsync(address));
        }

        public async Task<AddressDto> UpdateAsync(AddressDto addressDto)
        {
            var address = await addressRepository.GetAddressByIdAsync(addressDto.Id);
            address = mapper.Map(addressDto, address);

            return mapper.Map<AddressDto>(await addressRepository.UpdateAddressAsync(address));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await addressRepository.DeleteAddressAsync(id);
            return true;
        }
    }
}
