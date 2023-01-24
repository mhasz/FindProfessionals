using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindProfessionals.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(u => u.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(320)");

            builder.Property(u => u.Password)
                .IsRequired()
                .HasColumnType("varchar(16)");

            builder.HasOne(u => u.Address)
                .WithOne(a => a.User);

            builder.HasOne(u => u.Client)
                .WithOne(c => c.User);

            builder.HasOne(u => u.Professional)
                .WithOne(p => p.User);

            builder.ToTable("Users");
        }
    }
}
