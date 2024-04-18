using Microsoft.EntityFrameworkCore;
using WorldCities.Server.Data.Models;
using WorldCities.Server.Data.Models.Configurations;

namespace WorldCities.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Models.Country> Countries { get; set; }
        public DbSet<Models.City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.ApplyConfiguration<Country>(new CountryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration<City>(new CityEntityTypeConfiguration());
        }
    }
}
