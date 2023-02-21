using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task<Client> AddAsync(Guid userId);
        Task<bool> RemoveAsync(Guid id);
    }
}
