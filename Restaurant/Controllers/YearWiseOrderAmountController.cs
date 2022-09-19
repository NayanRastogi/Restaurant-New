using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System;
using System.Data;

namespace Restaurant.Controllers
{
    public class YearWiseOrderAmountController : Controller
    {
        ClsRestaurantBLL objrebll = new ClsRestaurantBLL();
        public IActionResult OrderAmount()
        {
            GetRestaurant();
            List<YearWiseOrderAmountModel> lstYear = new List<YearWiseOrderAmountModel>();
            return View(lstYear);
        }

        public IActionResult GetOrderAmount(int? RestaurantID = default,DateTime? YearWise=default)
        {
            ClsRestaurantBLL obj = new ClsRestaurantBLL();
            List<YearWiseOrderAmountModel> lstYear = new List<YearWiseOrderAmountModel>();
            obj.RestaurantID = Convert.ToInt32(RestaurantID);
            obj.YearWise = Convert.ToDateTime(YearWise);
            DateTime da = DateTime.Now;
            da = obj.YearWise;
            DataTable dt = obj.GetYearWiseOrderAmount();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                YearWiseOrderAmountModel objyear = new YearWiseOrderAmountModel();
                objyear.RestaurantName = dt.Rows[i]["RestaurantName"].ToString();
                objyear.OrderAmount =(float)Convert.ToDecimal(dt.Rows[i]["OrderAmount"].ToString());
                

                lstYear.Add(objyear);
            }
            GetRestaurant();
            return View("OrderAmount", lstYear);
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
