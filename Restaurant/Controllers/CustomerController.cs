using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using BusinessLogicLayer;
using System.Data;
using System.Collections.Generic;

namespace Restaurant.Controllers
{
    public class CustomerController : Controller
    {
        ClsCustomerBLL objcubll = new ClsCustomerBLL();
        ClsRestaurantBLL objrebll = new ClsRestaurantBLL();
        public IActionResult CustomerDetails()
        {

            List<RestaurantModel> lstrest = new List<RestaurantModel>();
            DataTable dt = objrebll.GetRestaurant();
            //var items = dt.To;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                RestaurantModel objres = new RestaurantModel();
                objres.RestaurantID = Convert.ToInt16(dt.Rows[i]["RestaurantID"].ToString());
                objres.RestaurantName = dt.Rows[i]["RestaurantName"].ToString();

                lstrest.Add(objres);

            }
            ViewBag.Data = lstrest;


            return View();

        }

        [HttpPost]
        public IActionResult CustomerDetails(ClsCustomerBLL objcu)
        {
            CustomerModel clsCuisine = new CustomerModel();
            DataTable result = objcubll.InsertCustomerDetails(objcu);
            ViewData["ResultInsert"] = result; // for dislaying message after updating data.
            return View("CustomerDetails","Customer");
        }
    }
}
