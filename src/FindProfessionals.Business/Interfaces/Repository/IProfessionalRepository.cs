using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IProfessionalRepository
    {
        Task<IEnumerable<Professional>> GetProfessionalsAsync();
        Task<Professional> GetProfessionalByIdAsync(Guid id);
        Task<Professional> InsertProfessionalAsync(Professional professional);
        Task<Professional> UpdateProfessionalAsync(Professional professional);
        Task<Professional> DeleteProfessionalAsync(Guid id);
    }
}
