using System;
using System.Collections.Generic;

namespace Restaurant.Models1
{
    public partial class Bill
    {
        public int BillsId { get; set; }
        public int OrderId { get; set; }
        public int RestaurantId { get; set; }
        public double BillAmount { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
