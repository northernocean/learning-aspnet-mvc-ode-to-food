using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Jazz Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Taj Mahal", Location="New York", Cuisine=CuisineType.Indian},
                new Restaurant {Id = 3, Name = "Senor Taco", Location="New Jersey", Cuisine=CuisineType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.AsEnumerable();
        }
    }
}
