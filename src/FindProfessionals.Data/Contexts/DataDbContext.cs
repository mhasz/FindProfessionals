using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindProfessionals.Data.Contexts
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
