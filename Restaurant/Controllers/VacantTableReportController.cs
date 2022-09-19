using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System;
using System.Data;

namespace Restaurant.Controllers
{
    public class VacantTableReportController : Controller
    {
        ClsRestaurantBLL objrebll=new ClsRestaurantBLL();
        public IActionResult VacantTable()
        {
            GetRestaurant();
            List<VacantTableModel> lstvacant = new List<VacantTableModel>();
            return View(lstvacant);
        }

       
        public IActionResult GetVacantTable(int? RestaurantID = default)
        {
            ClsRestaurantBLL obj = new ClsRestaurantBLL();            
            List<VacantTableModel> lstvacant = new List<VacantTableModel>();
            obj.RestaurantID = Convert.ToInt32(RestaurantID);
            DataTable dt = obj.GetVacantTable();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                VacantTableModel objvacant = new VacantTableModel();
                objvacant.RestaurantName = dt.Rows[i]["RestaurantName"].ToString();                
                objvacant.TableStatus = dt.Rows[i]["TableStatus"].ToString();
                objvacant.Location = dt.Rows[i]["Location"].ToString();

                lstvacant.Add(objvacant);     
            }
            GetRestaurant();
            return View("VacantTable", lstvacant);
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
