using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindProfessionals.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AddressName)
                .IsRequired()
                .HasColumnType("varchar(100)");            
            
            builder.Property(a => a.Complement)
                .IsRequired()
                .HasColumnType("varchar(100)");            
            
            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(50)");           
            
            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Adresses");
        }
    }
}
