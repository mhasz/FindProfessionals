namespace FindProfessionals.Domain.Entities
{
    public class Archive
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Guid JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}
