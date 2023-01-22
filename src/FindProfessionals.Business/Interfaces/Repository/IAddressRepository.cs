using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressByIdAsync(Guid id);
        Task InsertAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(Guid id);
    }
}
