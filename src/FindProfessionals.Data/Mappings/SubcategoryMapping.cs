using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindProfessionals.Data.Mappings
{
    public class SubcategoryMapping : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(S => S.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(s => s.Jobs)
                .WithOne(j => j.Subcategory)
                .HasForeignKey(j => j.SubcategoryId);

            builder.HasMany(s => s.Professionals)
                .WithMany(p => p.Subcategories);

            builder.ToTable("Subcategories");
        }
    }
}
