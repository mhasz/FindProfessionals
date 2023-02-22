namespace FindProfessionals.Domain.Entities
{
    public class Professional
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int Reputation { get; set; }
        public int Coins { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Job>? Jobs { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
