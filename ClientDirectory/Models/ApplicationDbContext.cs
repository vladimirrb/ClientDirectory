using Microsoft.EntityFrameworkCore;

namespace ClientDirectory.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка связей между сущностями
            modelBuilder.Entity<Client>()
                .HasOne(c => c.City)
                .WithMany(c => c.Clients)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Clients)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.City)
                .WithMany(c => c.Companies)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
