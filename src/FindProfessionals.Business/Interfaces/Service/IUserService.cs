using FindProfessionals.Domain.Dtos.User;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetails>> GetAsync();
        Task<UserDetails> GetByIdAsync(Guid id);
        Task<UserDetails> AddAsync(NewUser user);
        Task<UserDetails> UpdateAsync(EditUser user);
        Task<bool> RemoveAsync(Guid id);

        bool IsEmailUnique(string email);
        bool IsEmailUniqueEdit(EditUser user, string email);
        bool IsDocumentUnique(string document);

        Task<bool> ValidatePasswordAsync(User user);
    }
}
