using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindProfessionals.Data.Mappings
{
    public class JobMapping : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Title)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(j => j.Description)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.HasMany(j => j.Archives)
                .WithOne(a => a.Job)
                .HasForeignKey(a => a.JobId);

            builder.ToTable("Jobs");
        }
    }
}
