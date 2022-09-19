using BusinessLogicLayer;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restaurant.Models
{
    public class MenuItemModel
    {
        public int MenuItemID { get; set; }
        public int CuisineID { get; set; }
        public string ItemName { get; set; }

        public float ItemPrice { get; set; }

        public string Status { get; set; }

    }
}
