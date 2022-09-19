
using RestaurantAPI.Model;
using RestaurantAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurant objres = new RestaurantRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAllRestaurant()
        {
            return objres.GetAllRestaurant();
        }
        [HttpGet]
        public ActionResult<Restaurant> GetRestaurant(int id)
        {
            return objres.GetRestaurant(id);
        }
    }
}
