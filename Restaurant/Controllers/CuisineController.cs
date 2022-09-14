using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using BusinessLogicLayer;
using System.Data;
using System.Collections.Generic;
using System;

namespace Restaurant.Controllers
{
    public class CuisineController : Controller
    {
        ClsCuisionBLL objcubll = new ClsCuisionBLL();
        ClsRestaurantBLL objrebll=new ClsRestaurantBLL();
       
        public IActionResult Cuisine()
        {
            List<Cuisine> lstCuisine = new List<Cuisine>();
            DataTable dt = objcubll.SelectCuisine();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Cuisine clsCuisine = new Cuisine();               
                clsCuisine.CuisineID = Convert.ToInt16(dt.Rows[i]["CuisineID"].ToString());
                //clsCuisine.RestaurantID=Convert.ToInt16(dt.Rows[i]["RestaurantID"].ToString());
                clsCuisine.RestaurantName = Convert.ToString(dt.Rows[i]["RestaurantName"].ToString());
                clsCuisine.CuisineName = dt.Rows[i]["CuisineName"].ToString();
                clsCuisine.Status = dt.Rows[i]["Status"].ToString();
                lstCuisine.Add(clsCuisine);
            }
            return View(lstCuisine);

        }

        public IActionResult InsertCuisine()
        {
           // objrebll.RestaurantID = Convert.ToInt16((RestaurantID).ToString());
            List<RestaurantModel> lstRest = new List<RestaurantModel>();
            DataTable dt = objrebll.GetRestaurant();
            //var items = dt.To;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                RestaurantModel objres = new RestaurantModel();
                objres.RestaurantID = Convert.ToInt16(dt.Rows[i]["RestaurantID"].ToString());
                objres.RestaurantName = dt.Rows[i]["RestaurantName"].ToString();

                lstRest.Add(objres);
              
            }
            ViewBag.Data = lstRest;
            
            return View();
        }


        [HttpPost]
        public IActionResult InsertCuisine(ClsCustomerBLL objcu)
        {
            //objrebll.RestaurantID = Convert.ToInt16((RestaurantID).ToString());
            Cuisine clsCuisine = new Cuisine();
            DataTable result = objcubll.InsertCuisine(objcubll);
            ViewData["ResultInsert"] = result; // for dislaying message after updating data.
            return View("Cuisine", "Cuisine");

        }
        // Edit gridview data
        public IActionResult EditCusine(int CuisineID)
        {
            objcubll.CuisineID = Convert.ToInt16(CuisineID);
            DataTable dt = objcubll.SelectCuisineByCuisineID();
            List<Cuisine> lstCuisine = new List<Cuisine>();
            Cuisine clsCuisine = new Cuisine();
            clsCuisine.CuisineID = Convert.ToInt16(dt.Rows[0]["CuisineID"].ToString());
            clsCuisine.RestaurantName = dt.Rows[0]["RestaurantName"].ToString();
            clsCuisine.CuisineName = dt.Rows[0]["CuisineName"].ToString();
            clsCuisine.Status = dt.Rows[0]["Status"].ToString();
            lstCuisine.Add(clsCuisine);
            return View(clsCuisine);
        }
            
        
        [HttpPost]
        public IActionResult EditCusine(ClsCuisionBLL objcu)
        {
            //objcubll.CuisineID = Convert.ToInt16(CuisineID);
            
            Cuisine clsCuisine = new Cuisine();
            DataTable result = objcubll.UpdateCuisine(objcu);
            ViewData["ResultUpdate"] = result; // for dislaying message after updating data.
            return View(clsCuisine);

        }


      //  Delete Gridview Data

        public ActionResult DeleteCuisine(int CuisineID)
        {
            objcubll.CuisineID = Convert.ToInt16(CuisineID);
            DataTable dt = objcubll.SelectCuisineByCuisineID();
            List<Cuisine> lstCuisine = new List<Cuisine>();
            Cuisine clsCuisine = new Cuisine();
            clsCuisine.CuisineID = Convert.ToInt16(dt.Rows[0]["CuisineID"].ToString());
            clsCuisine.RestaurantName = dt.Rows[0]["RestaurantName"].ToString();
            clsCuisine.CuisineName = dt.Rows[0]["CuisineName"].ToString();
            clsCuisine.Status = dt.Rows[0]["Status"].ToString();
            lstCuisine.Add(clsCuisine);
            return View(clsCuisine);
        }


        [HttpPost]
        public ActionResult DeleteCuisine(ClsCuisionBLL objcu)
        {
            Cuisine clsCuisine = new Cuisine();
            DataTable result = objcubll.DeleteCuisine(objcu);
            ViewData["ResultDelete"] = result; // for dislaying message after deleting data.
            return View(clsCuisine);
        }

    }
}
