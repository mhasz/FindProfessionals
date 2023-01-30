using FindProfessionals.Domain.Enums;

namespace FindProfessionals.Domain.Dtos.User
{
    public class NewUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserDocumentType DocumentType { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
