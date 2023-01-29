using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FindProfessionals.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataDbContext _context;

        public UserRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Search(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> InsertUserAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            _context.Users.Remove(new User { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
