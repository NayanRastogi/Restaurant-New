using System;
using System.Collections.Generic;

namespace Restaurant.Models1
{
    public partial class Cuisine
    {
        public Cuisine()
        {
            RestaurantMenuItems = new HashSet<RestaurantMenuItem>();
        }

        public int CuisineId { get; set; }
        public int? RestaurantId { get; set; }
        public string CuisineName { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public virtual Restaurant? Restaurant { get; set; }
        public virtual ICollection<RestaurantMenuItem> RestaurantMenuItems { get; set; }
    }
}
