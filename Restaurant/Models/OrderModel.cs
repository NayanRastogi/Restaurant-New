
using System.Data;
using System;
namespace Restaurant.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }

        public int MenuItemID { get; set; }

        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }

        public int DiningTableID { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }


    }
}
