using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using BusinessLogicLayer;
using RestaurantAPI.Model;
using System.Data;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        ClsCuisionBLL ClsCuisine = new ClsCuisionBLL();

        [HttpGet]
        public ActionResult <IEnumerable<Cuisine>> SelectCuisineDetails()
        {
            var Cuisinelist = ClsCuisine.SelectCuisine();
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

    }
}
