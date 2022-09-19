using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using BusinessLogicLayer;
using RestaurantAPI.Model;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        ClsCuisionBLL ClsCuisinebll = new ClsCuisionBLL();
       
        [HttpGet]
        public ActionResult<IEnumerable<Cuisine>> SelectCuisineDetails()
        {
            var Cuisinelist= ClsCuisinebll.SelectCuisine();
            DataTable dt = new DataTable("Cuisine");
            dt.Columns.Add("CuisineId", typeof(Int32));
            dt.Columns.Add("CuisineName", typeof(string));
            dt.Columns.Add("RestaurantID", typeof(string));
            
            List<Cuisine> CuisineList = new List<Cuisine>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cuisine objCu = new Cuisine();
                objCu.CuisineID = Convert.ToInt32(dt.Rows[i]["CuisineID"]);
                objCu.CuisineName = dt.Rows[i]["CuisineName"].ToString();
                objCu.RestaurantID = Convert.ToInt32(dt.Rows[i]["RestaurantID"]);
                
                CuisineList.Add(objCu);
            }
            return (CuisineList);
            
        }

        [HttpGet("{CuisineID}")]
        public ActionResult<Cuisine> SelectCuisineByCuisineID(int CuisineID)
        {
          return SelectCuisineByCuisineID(CuisineID);
           
        }

    }
}
