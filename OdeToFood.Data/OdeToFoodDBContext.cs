using Microsoft.EntityFrameworkCore;
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

            //https://nodogmablog.bryanhogan.net/2018/09/saving-enums-with-entity-framework-core/
            modelBuilder
                .Entity<Restaurant>()
                .Property(e => e.Cuisine)
                .HasConversion(c => (int)c, c => (CuisineType)c);
        }
    }
}
