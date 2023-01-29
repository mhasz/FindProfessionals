using FindProfessionals.Domain.Enums;

namespace FindProfessionals.Domain.Dtos.User
{
    public class EditUser
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
