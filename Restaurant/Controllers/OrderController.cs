using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using BindingData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLogicLayer;
using Restaurant.Models;
using System.Data;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        ClsRestaurantBLL objrebll = new ClsRestaurantBLL();
        ClsMenuItemBLL objmenubll=new ClsMenuItemBLL();
        ClsDiningTableBLL objdiningbll=new ClsDiningTableBLL();
        public IActionResult InsertOrder()
        {
            GetRestaurant();
            GetMenuItem();
            GetDiningTable();
            return View();
        }

        [HttpPost]
        public IActionResult InsertOrder(int? RestaurantID = default, int? MenuItemID = default, int? DiningTableID = default)
        {

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
        public void GetMenuItem()
        {
            List<MenuItemModel> lstmenu = new List<MenuItemModel>();
            DataTable dt = objmenubll.SelectMenuItem();
            //var items = dt.To;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                MenuItemModel objmenu = new MenuItemModel();
                objmenu.MenuItemID = Convert.ToInt16(dt.Rows[i]["MenuItemID"].ToString());
                objmenu.ItemName = dt.Rows[i]["ItemName"].ToString();

                lstmenu.Add(objmenu);
                ViewBag.Data = lstmenu;
            }
        }

        public void GetDiningTable()
        {
            List<DiningTableModel> lstdining = new List<DiningTableModel>();
            DataTable dt = objdiningbll.SelectDiningTable();
            //var items = dt.To;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DiningTableModel objdining = new DiningTableModel();
                objdining.DiningTableID = Convert.ToInt16(dt.Rows[i]["DiningTableID"].ToString());
                objdining.Location = dt.Rows[i]["Location"].ToString();

                lstdining.Add(objdining);
                ViewBag.Data = lstdining;
            }
        }
    }
}
