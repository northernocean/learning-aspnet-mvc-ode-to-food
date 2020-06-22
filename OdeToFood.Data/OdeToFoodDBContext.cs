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

    }
}
