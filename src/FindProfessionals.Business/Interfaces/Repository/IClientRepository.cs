using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(Guid id);
        Task<Client> InsertClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task<Client> DeleteClientAsync(Guid id);
    }
}
