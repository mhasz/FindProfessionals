namespace FindProfessionals.Domain.Entities
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Stars { get; set; }
        public string? Comment { get; set; }
        public DateTime Published { get; set; }
        public bool Active { get; set; }

        public Guid JobId { get; set; }
        public virtual Job Job { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        public Guid ProfessionalId { get; set; }
        public virtual Professional Professional { get; set; }
    }
}
