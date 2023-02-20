using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataDbContext _context;

        public AddressRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Address> GetAddressByIdAsync(Guid id)
        {
            return await _context.Adresses.FindAsync(id);
        }

        public async Task<Address> InsertAddressAsync(Address address)
        {
            await _context.Adresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            _context.Adresses.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task DeleteAddressAsync(Guid id)
        {
            var address = await _context.Adresses.FindAsync(id);
            _context.Adresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
