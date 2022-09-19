using System;
using System.Collections.Generic;

namespace Restaurant.Models1
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Cuisines = new HashSet<Cuisine>();
            Customers = new HashSet<Customer>();
            DiningTables = new HashSet<DiningTable>();
            Orders = new HashSet<Order>();
        }

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; } = null!;
        public string RestaurantAddress { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public virtual ICollection<Cuisine> Cuisines { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<DiningTable> DiningTables { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
