using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDBContext DbContext;

        public SqlRestaurantData(OdeToFoodDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            DbContext.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
                DbContext.Remove(restaurant);
            return restaurant;

        }

        public Restaurant GetById(int id)
        {
            return DbContext.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return DbContext.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return DbContext.Restaurants.ToList();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return DbContext.Restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).ToList();
        }

        public Restaurant Update(Restaurant restaurant)
        {
            DbContext.Restaurants.Update(restaurant);
            return restaurant;
        }
    }
}
