using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface IUserService
    {
        Task<bool> Add(User user);
        Task<bool> Update(User user);
        Task<bool> Remove(Guid id);

        bool IsEmailUnique(User user, string email);
        bool IsDocumentUnique(string document);
    }
}
