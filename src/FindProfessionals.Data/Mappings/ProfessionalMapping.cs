using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindProfessionals.Data.Mappings
{
    public class ProfessionalMapping : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.About)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.ProfilePictureUrl)
                .IsRequired()
                .HasColumnType("varchar(2048)");

            builder.HasMany(p => p.Jobs)
                .WithMany(j => j.Professionals);

            builder.HasMany(p => p.Ratings)
                .WithOne(r => r.Professional)
                .HasForeignKey(r => r.ProfessionalId);

            builder.ToTable("Professionals");
        }
    }
}
