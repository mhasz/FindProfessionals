using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindProfessionals.Data.Mappings
{
    public class ArchiveMapping : IEntityTypeConfiguration<Archive>
    {
        public void Configure(EntityTypeBuilder<Archive> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Url)
                .IsRequired()
                .HasColumnType("varchar(2048)");

            builder.ToTable("Archives");
        }
    }
}
