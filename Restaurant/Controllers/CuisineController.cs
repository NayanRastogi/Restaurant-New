using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using BusinessLogicLayer;
using System.Data;

namespace Restaurant.Controllers
{
    public class CuisineController : Controller
    {
        ClsCuisionBLL objcubll = new ClsCuisionBLL();

       
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
        public IActionResult EditCusine(ClsCuisionBLL objcubll)
        {
            //objcubll.CuisineID = Convert.ToInt16(CuisineID);
            
            Cuisine clsCuisine = new Cuisine();
            DataTable result = objcubll.UpdateCuisine(objcubll);
            ViewData["resultUpdate"] = result; // for dislaying message after updating data.
            return View();

        }


        // Delete Gridview Data

        //public ActionResult DeleteCuisine(int CuisineID)
        //{
        //    objcubll.CuisineID = Convert.ToInt16(CuisineID);
        //    DataTable dt = objcubll.SelectCuisineByCuisineID();
        //    List<Cuisine> lstCuisine = new List<Cuisine>();
        //    Cuisine clsCuisine = new Cuisine();
        //    clsCuisine.CuisineID = Convert.ToInt16(dt.Rows[0]["CuisineID"].ToString());
        //    clsCuisine.RestaurantName = dt.Rows[0]["RestaurantName"].ToString();
        //    clsCuisine.CuisineName = dt.Rows[0]["CuisineName"].ToString();
        //    clsCuisine.Status = dt.Rows[0]["Status"].ToString();
        //    lstCuisine.Add(clsCuisine);
        //    return View(clsCuisine);
        //}


        //[HttpPost]
        //public ActionResult DeleteCuisine(ClsCuisionBLL objcubll)
        //{
        //    Cuisine clsCuisine = new Cuisine();
        //    DataTable result = objcubll.DeleteCuisine(objcubll);
        //    ViewData["ResultDelete"] = result; // for dislaying message after deleting data.
        //    return View(clsCuisine);
        //}

    }
}
