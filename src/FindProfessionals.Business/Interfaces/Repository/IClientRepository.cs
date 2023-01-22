using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(Guid id);
        Task InsertClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id);
    }
}
