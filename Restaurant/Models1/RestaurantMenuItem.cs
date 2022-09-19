using System;
using System.Collections.Generic;

namespace Restaurant.Models1
{
    public partial class RestaurantMenuItem
    {
        public RestaurantMenuItem()
        {
            Orders = new HashSet<Order>();
        }

        public int MenuItemId { get; set; }
        public int? CuisineId { get; set; }
        public string ItemName { get; set; } = null!;
        public double? ItemPrice { get; set; }
        public string Status { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public virtual Cuisine? Cuisine { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
