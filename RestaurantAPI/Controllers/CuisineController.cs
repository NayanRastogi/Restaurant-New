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
        public ActionResult<IEnumerable<Cuisine>> SelectCuisine()
        {
            return SelectCuisine();
            
        }

        [HttpGet("{CuisineID}")]
        public ActionResult<Cuisine> SelectCuisineByCuisineID(int CuisineID)
        {
          return SelectCuisineByCuisineID(CuisineID);
           
        }

    }
}
