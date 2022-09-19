using System.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class YearWiseOrderAmountModel
    {
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ? YearWise { get; set; }

        public float OrderAmount { get; set; }
    }
}
