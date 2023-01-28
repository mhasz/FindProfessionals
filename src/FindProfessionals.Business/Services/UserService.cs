using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Add(User user)
        {
            // encrypt password
            user.RegistrationDate = DateTime.UtcNow.Date;
            user.Role = Domain.Enums.UserRole.user;
            user.Active= true;

            await _userRepository.InsertUserAsync(user);
            return true;
        }

        public async Task<bool> Update(User user)
        {
            // encrypt password
            user.LastUpdate = DateTime.UtcNow.Date;

            await _userRepository.UpdateUserAsync(user);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            if(_userRepository.GetUserByIdAsync(id).Result.Client.Jobs.Any())
            {
                // notification - this user has registered jobs.
                return false;
            }

            await _userRepository.DeleteUserAsync(id);
            return true;
        }

        public bool IsEmailUnique(User user, string email)
        {
            return _userRepository.Search(x => x.Email == email && x.Id != user.Id).Result.Any() != null;
        }

        public bool IsDocumentUnique(string document)
        {
            return _userRepository.Search(x => x.Document == document).Result.Any() != null;
        }
    }
}
