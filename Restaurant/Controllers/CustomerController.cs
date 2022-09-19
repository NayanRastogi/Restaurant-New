
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using BusinessLogicLayer;
using System.Data;
using System.Collections.Generic;
using System.Security.Policy;

namespace Restaurant.Controllers
{
    public class CustomerController : Controller
    {
        ClsRestaurantBLL objrebll = new ClsRestaurantBLL();
        
        public IActionResult CustomerDetails()
        {
            GetRestaurant();           
            return View();           
        }

        [HttpPost]
        public IActionResult CustomerDetails(ClsCustomerBLL objcu)
        {
            //int ResId = Convert.ToInt16(ViewData["ResId"].ToString());
            ClsCustomerBLL obj = new ClsCustomerBLL();
            obj.CustomerName = objcu.CustomerName;
            obj.MobileNo = objcu.MobileNo;
            obj.RestaurantID=objcu.RestaurantID;
            obj.InsertCustomerDetails();
            if(obj.OutParam==2)            
                ViewData["ResultInsert"] = "Customer details already exists!"; // for dislaying message after updating data.
            else
                ViewData["ResultInsert"] = "Data inserted successfully!";
            GetRestaurant();


            return View();
        }

        public void GetRestaurant()
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
                ViewBag.Data = lstrest;
            }
        }
    }
}
