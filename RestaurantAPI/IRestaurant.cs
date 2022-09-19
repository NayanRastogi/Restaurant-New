using System.Collections.Generic;
using RestaurantAPI.Model;
using BusinessLogicLayer;

namespace RestaurantAPI
{
    public interface IRestaurant
    {
       
        List<Restaurant> GetAllRestaurant();
        Restaurant GetRestaurant(int RestaurantID);
    }
}
