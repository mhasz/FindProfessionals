namespace FindProfessionals.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Job>? Jobs { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
