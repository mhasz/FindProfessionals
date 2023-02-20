namespace FindProfessionals.Domain.Entities
{
    public class Subcategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CostCoins { get; set; }

        public virtual ICollection<Job>? Jobs { get; set; }
        public virtual ICollection<Professional>? Professionals { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
