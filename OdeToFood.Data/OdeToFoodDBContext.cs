using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodDBContext : DbContext
    {

        public OdeToFoodDBContext(DbContextOptions<OdeToFoodDBContext> options)
            : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Restaurant>()
                .Property(e => e.Cuisine)
                .HasConversion(c => (int)c, c => (CuisineType)c);
        }
    }
}
