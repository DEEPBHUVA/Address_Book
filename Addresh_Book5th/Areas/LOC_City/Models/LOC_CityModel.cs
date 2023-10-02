using System.ComponentModel.DataAnnotations;

namespace Addresh_Book5th.Areas.LOC_City.Models
{
    public class LOC_CityModel
    { 
        public int? CityID { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        public int StateID { get; set; }
        public string StateName { get; set; } 
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Please Enter City Code")]
        public string CityCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Modified { get; set;}
    }
            
    public class LOC_City_Dropdown
    {
        public int? CityID { get; set; }
        public string CityName { get; set; }
    }
}
