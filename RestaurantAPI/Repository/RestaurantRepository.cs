using RestaurantAPI.Model;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer;

namespace RestaurantAPI.Repository
{
    public class RestaurantRepository: IRestaurant
    {
        ClsCuisionBLL ClsCuisinebll = new ClsCuisionBLL();
        List<Restaurant> lisRes = new List<Restaurant>
        {
            new Restaurant{RestaurantID=2, RestaurantName=" Barbeque Nation", RestaurantAddress="2nd Floor N-19, Block N, Connaught Place, New Delhi", MobileNo="8899889988" },
            new Restaurant{RestaurantID=3, RestaurantName="Food Exchange", RestaurantAddress="12345 IGI Airport New Delhi Aerocity, Delhi", MobileNo="8899889987" },
            new Restaurant{RestaurantID=1002, RestaurantName="Yello Chilly", RestaurantAddress="1234 Noida", MobileNo="9853673737" },
           
        };
        public List<Restaurant> GetAllRestaurant()
        {
            return lisRes;
        }

        public Restaurant GetRestaurant(int RestaurantID)
        {
            return lisRes.FirstOrDefault(x => x.RestaurantID == RestaurantID);
        }

    }
}
