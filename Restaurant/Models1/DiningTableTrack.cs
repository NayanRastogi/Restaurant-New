using System;
using System.Collections.Generic;

namespace Restaurant.Models1
{
    public partial class DiningTableTrack
    {
        public int DiningTableTrackId { get; set; }
        public int? DiningTableId { get; set; }
        public string? TableStatus { get; set; }
        public string Status { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyOn { get; set; }

        public virtual DiningTable? DiningTable { get; set; }
    }
}
