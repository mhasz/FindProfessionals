using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressByIdAsync(Guid id);
        Task<Address> InsertAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(Guid id);
    }
}
