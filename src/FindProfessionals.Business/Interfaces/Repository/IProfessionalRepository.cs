using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IProfessionalRepository
    {
        Task<IEnumerable<Professional>> GetProfessionalsAsync();
        Task<Professional> GetProfessionalByIdAsync(Guid id);
        Task InsertProfessionalAsync(Professional professional);
        Task UpdateProfessionalAsync(Professional professional);
        Task DeleteProfessionalAsync(Guid id);
    }
}
