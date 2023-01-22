using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindProfessionals.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataDbContext _context;

        public ClientRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task InsertClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(Guid id)
        {
            _context.Clients.Remove(new Client { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
