using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task InsertUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}
