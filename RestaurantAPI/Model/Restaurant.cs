using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer;
namespace RestaurantAPI.Model
{
    public class Restaurant
    {

        public int RestaurantID { get; set; } = 0;
        public string RestaurantName { get; set; } = "";
        public string RestaurantAddress { get; set; } = "";

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "10 Digit Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter 10 Digit Number Start From 9,8,7")]
        public string MobileNo { get; set; } = "";
        public string Status { get; set; } = "";

        public int UserID { get; set; } = 0;


    }
}
