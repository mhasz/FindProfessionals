using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IArchiveRepository
    {
        Task<Archive> GetArchiveByIdAsync(Guid id);
        Task<IEnumerable<Archive>> GetArchivesByJobIdAsync(Guid id);
        Task InsertArchiveAsync(Archive archive);
        Task DeleteArchiveAsync(Guid id);
    }
}
