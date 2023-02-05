using AutoMapper;
using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Dtos.User;
using FindProfessionals.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FindProfessionals.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IJwtTokenService jwtTokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDetails>> GetAsync()
        {
            return _mapper.Map<List<UserDetails>>(await _userRepository.GetUsersAsync());
        }

        public async Task<UserDetails> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UserDetails>(await _userRepository.GetUserByIdAsync(id));
        }

        public async Task<UserDetails> AddAsync(NewUser newUser)
        {
            var user = _mapper.Map<User>(newUser);

            ConvertPasswordInHash(user);

            user.RegistrationDate = DateTime.UtcNow.Date;
            user.Role = Domain.Enums.UserRole.user;
            user.Active= true;

            return _mapper.Map<UserDetails>(await _userRepository.InsertUserAsync(user));
        }

        public async Task<UserDetails> UpdateAsync(EditUser editUser)
        {
            var user = await _userRepository.GetUserByIdAsync(editUser.Id);

            if (user == null)
                throw new NullReferenceException();

            user = _mapper.Map(editUser, user);

            ConvertPasswordInHash(user);

            user.LastUpdate = DateTime.UtcNow.Date;

            return _mapper.Map<UserDetails>(await _userRepository.UpdateUserAsync(user));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
            return true;
        }

        public bool IsEmailUnique(string email)
        {
            return !_userRepository.SearchAll(x => x.Email == email).Result.Any();
        }

        public bool IsEmailUniqueEdit(EditUser user, string email)
        {
            return !_userRepository.SearchAll(x => x.Email == email && x.Id != user.Id).Result.Any();
        }

        public bool IsDocumentUnique(string document)
        {
            return !_userRepository.SearchAll(x => x.Document == document).Result.Any();
        }

        public async Task<string> ValidateUserAsync(UserLogin userLogin)
        {
            var user = await _userRepository.Search(x => x.Email == userLogin.Email.ToLower());

            if (user == null)
                return null;

            if (!await ValidatePasswordAsync(user, userLogin))
                return null;

            return _jwtTokenService.GenerateToken(user);
        }

        private async Task<bool> ValidatePasswordAsync(User user, UserLogin userLogin)
        {
            var passwordHasher = new PasswordHasher<User>();
            var status = passwordHasher.VerifyHashedPassword(user, user.Password, userLogin.Password);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await RehashPasswordAsync(user, userLogin);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void ConvertPasswordInHash(User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);
        }

        private async Task RehashPasswordAsync(User user, UserLogin userLogin)
        {
            _mapper.Map(userLogin.Password, user);
            ConvertPasswordInHash(user);
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
