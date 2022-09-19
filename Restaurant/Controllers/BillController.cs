using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System.Data;

namespace Restaurant.Controllers
{
    public class BillController : Controller
    {
        ClsCustomerBLL objcu = new ClsCustomerBLL();
        public IActionResult InsertBillDetail()
        {
            GetCustomer();
            return View();
        }

        [HttpPost]
        public IActionResult InsertBillDetail(ClsBillBLL objbill)
        { //int ResId = Convert.ToInt16(ViewData["ResId"].ToString());
            ClsBillBLL objbl = new ClsBillBLL();
            objbl.OrderID = objbill.OrderID;
            
            objbl.CustomerID = objbill.CustomerID;
            objbl.InsertBillDetails();
            if (objbl.OutParam == 2)
                ViewData["ResultInsert"] = "Bill details already exists!"; // for dislaying message after updating data.
            else
                ViewData["ResultInsert"] = "Data inserted successfully!";
            GetCustomer();
            return View();
        }

        public void GetCustomer()
        {
            List<CustomerModel> lstcu = new List<CustomerModel>();
            DataTable dt = objcu.SelectCustomer();
            //var items = dt.To;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                CustomerModel objCust = new CustomerModel();
                objCust.CustomerID = Convert.ToInt16(dt.Rows[i]["CustomerID"].ToString());
                objCust.CustomerName = dt.Rows[i]["CustomerName"].ToString();

                lstcu.Add(objCust);
                ViewBag.Data = lstcu;
            }
        }
    }
}
