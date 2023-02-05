using FindProfessionals.Domain.Entities;
using System.Linq.Expressions;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> Search(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> SearchAll(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> InsertUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}
