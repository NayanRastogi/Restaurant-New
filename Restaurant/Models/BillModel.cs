namespace Restaurant.Models
{
    public class BillModel
    {
       public int BillsID { get; set; }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string Status { get; set; } = "";
    }
}
