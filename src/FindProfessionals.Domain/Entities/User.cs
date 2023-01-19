using FindProfessionals.Domain.Enums;

namespace FindProfessionals.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserDocumentType DocumentType { get; set; }
        public int Document { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public UserRole Role { get; set; }
        public bool Active { get; set; }

        public virtual Address Address { get; set; }
        public virtual Client? Client { get; set; }
        public virtual Professional? Professional { get; set; }
    }
}
