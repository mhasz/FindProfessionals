using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindProfessionals.Data.Mappings
{
    public class RatingMapping : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Comment)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.HasOne(r => r.Job);

            builder.ToTable("Ratings");
        }
    }
}
