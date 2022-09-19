using System;
using System.Collections.Generic;

namespace Restaurant.Models1
{
    public partial class Order
    {
        public Order()
        {
            Bills = new HashSet<Bill>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int RestaurantId { get; set; }
        public int MenuItemId { get; set; }
        public int ItemQuantity { get; set; }
        public double OrderAmount { get; set; }
        public int DiningTableId { get; set; }
        public string Status { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public virtual DiningTable DiningTable { get; set; } = null!;
        public virtual RestaurantMenuItem MenuItem { get; set; } = null!;
        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
