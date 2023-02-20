using FindProfessionals.Domain.Dtos.Address;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface IAddressService
    {
        Task<AddressDto> GetByIdAsync(Guid id);
        Task<AddressDto> AddAsync(AddressDto addressDto, Guid userId);
        Task<AddressDto> UpdateAsync(AddressDto addressDto);
        Task<bool> RemoveAsync(Guid id);
    }
}
