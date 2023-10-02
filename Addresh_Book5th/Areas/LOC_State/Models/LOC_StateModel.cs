using System.ComponentModel.DataAnnotations;

namespace Addresh_Book5th.Areas.LOC_State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }

        [Required(ErrorMessage = "Please Enter State Name")]
        public string? StateName { get; set; }
        public string? CountryName { get; set; }

        [Required(ErrorMessage = "Please Enter State Code")]
        public string? StateCode { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public int CountryID {  get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class LOC_State_Dropdown
    {
        public int StateID { get; set; }
        public string? StateName { get; set; }
    }
}
