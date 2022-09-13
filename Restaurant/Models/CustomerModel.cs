using BusinessLogicLayer;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public string CustomerName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "10 Digit Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter 10 Digit Number Start From 9,8,7")]
        public string MobileNo { get; set; } 

        public string Status { get; set; }

    }
}
