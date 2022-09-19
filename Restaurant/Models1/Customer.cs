using System;
using System.Collections.Generic;

namespace Restaurant.Models1
{
    public partial class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }

        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
