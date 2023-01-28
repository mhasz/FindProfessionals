using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface IUserService
    {
        Task<bool> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> RemoveAsync(Guid id);

        bool IsEmailUnique(User user, string email);
        bool IsDocumentUnique(string document);

        Task<bool> ValidatePasswordAsync(User user);
    }
}
