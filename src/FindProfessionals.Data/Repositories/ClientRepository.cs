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
            return await _context.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client> GetClientByUserLogged(Guid id)
        {
            return await _context.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<Client> InsertClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
