using BusinessLogicLayer;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Cuisine
    {
        public int CuisineID { get; set; }

        public int RestaurantID { get; set; }


        public string RestaurantName { get; set; } = "";

        [Required]
        public string CuisineName { get; set; } = "";
        public string Status { get; set; } = "";    
    }
}

