using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class BillController : Controller
    {
        public IActionResult InsertBillDetail()
        {
            return View();
        }
    }
}
