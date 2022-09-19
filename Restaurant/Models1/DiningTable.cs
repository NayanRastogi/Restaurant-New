using System;
using System.Collections.Generic;

namespace Restaurant.Models1
{
    public partial class DiningTable
    {
        public DiningTable()
        {
            DiningTableTracks = new HashSet<DiningTableTrack>();
            Orders = new HashSet<Order>();
        }

        public int DiningTableId { get; set; }
        public int RestaurantId { get; set; }
        public string Location { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<DiningTableTrack> DiningTableTracks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
