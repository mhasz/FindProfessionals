using FindProfessionals.Domain.Entities;
using FindProfessionals.Domain.Enums;

namespace FindProfessionals.Domain.Dtos.Job
{
    public class NewJob
    {
        public Guid SubcategoryId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public JobType Type { get; set; }
        public JobPriority Priority { get; set; }

        public virtual ICollection<Archive>? Archives { get; set; }
    }
}
