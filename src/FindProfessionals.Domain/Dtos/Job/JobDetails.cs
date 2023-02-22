using FindProfessionals.Domain.Entities;
using FindProfessionals.Domain.Enums;

namespace FindProfessionals.Domain.Dtos.Job
{
    public class JobDetails
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public JobType Type { get; set; }
        public JobPriority Priority { get; set; }
        public DateTime Published { get; set; }

        public virtual Subcategory Subcategory { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Archive>? Archives { get; set; }
        public virtual ICollection<Professional>? Professionals { get; set; }
    }
}
