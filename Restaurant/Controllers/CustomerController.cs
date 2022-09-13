using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using BusinessLogicLayer;
using System.Data;

namespace Restaurant.Controllers
{
    public class CustomerController : Controller
    {
        ClsCustomerBLL objcubll = new ClsCustomerBLL();
        public IActionResult CustomerDetail()
        { 
            

            

            return View();
        }
    }
}
