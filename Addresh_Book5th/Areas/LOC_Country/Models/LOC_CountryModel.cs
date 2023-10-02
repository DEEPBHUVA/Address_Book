using System.ComponentModel.DataAnnotations;

namespace Addresh_Book5th.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        public int? CountryID { get; set; }

        [Required(ErrorMessage = "Please enter Country Name")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Please enter Country Code"), MaxLength(10)]
        public string CountryCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class LOC_Country_DropdownModel
    {
        public int CountryID { get; set;}
        public string? CountryName { get; set;}
    }
}
