using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindProfessionals.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Jobs)
                .WithOne(j => j.Client)
                .HasForeignKey(j => j.ClientId);

            builder.HasMany(c => c.Ratings)
                .WithOne(r => r.Client)
                .HasForeignKey(r => r.ClientId);

            builder.ToTable("Clients");
        }
    }
}
