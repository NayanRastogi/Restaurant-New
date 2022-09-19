
using System.Data;
using System;

namespace Restaurant.Models
{
    public class VacantTableModel
    {
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }

        public string TableStatus { get; set; }

        public string Location { get; set; }
    }
}
