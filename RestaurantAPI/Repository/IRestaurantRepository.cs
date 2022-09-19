using System.Collections.Generic;
using RestaurantAPI.Model;

namespace RestaurantAPI.Repository
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetAllRestaurant();
        Restaurant GetRestaurant(int RestaurantID);
    }
}
