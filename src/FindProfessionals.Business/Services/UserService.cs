using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FindProfessionals.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddAsync(User user)
        {
            ConvertPasswordInHash(user);

            user.RegistrationDate = DateTime.UtcNow.Date;
            user.Role = Domain.Enums.UserRole.user;
            user.Active= true;

            await _userRepository.InsertUserAsync(user);
            return true;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            ConvertPasswordInHash(user);

            user.LastUpdate = DateTime.UtcNow.Date;

            await _userRepository.UpdateUserAsync(user);
            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
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

        private void ConvertPasswordInHash(User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);
        }

        public async Task<bool> ValidatePasswordAsync(User user)
        {
            var currentUser = await _userRepository.GetUserByIdAsync(user.Id);
            if (currentUser == null)
                return false;

            var passwordHasher = new PasswordHasher<User>();
            var status = passwordHasher.VerifyHashedPassword(user, currentUser.Password, user.Password);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateAsync(user);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
