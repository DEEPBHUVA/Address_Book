using System.ComponentModel.DataAnnotations;

namespace Addresh_Book5th.Areas.MST_Student.Models
{
    public class MST_StudentModel
    {
        public int? StudentID { get; set; }
        //==================================
        [Required(ErrorMessage = "Please Select Branch Name")]
        public int BranchID { get; set; }
        //==================================
        [Required(ErrorMessage = "Please Select City Name")]
        public int CityID { get; set; }
        //==================================
        public string CityName { get; set; }
        //==================================
        [Required(ErrorMessage = "Student name is required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Must be between 3 and 50 characters", MinimumLength = 3)]
        public string StudentName { get; set; }
        //==================================
        [Required(ErrorMessage = "Mobile No. is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                            ErrorMessage = "Entered phone format is not valid.")]
        public string MobileNoStudent { get; set; }
        //==================================
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set;}
        //==================================
        [Required(ErrorMessage = "Mobile No. is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                            ErrorMessage = "Entered phone format is not valid.")]
        public string MobileNoFather { get; set; }
        //==================================
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        //==================================
        [Required(ErrorMessage = "Select BirthDate, it is required")]
        public DateTime BirthDate { get; set; }
        //==================================
        [Required(ErrorMessage = "Enter Age, it is required")]
        [Range(1, 100, ErrorMessage = "Please enter the correct value")]
        public int Age { get; set; }
        //==================================
        [Required(ErrorMessage = "Please Choose atleast one")]
        public string IsActive { get; set; }
        //==================================
        [Required(ErrorMessage = "Please Choose atleast one")]
        public string Gender { get; set; }
        //==================================
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "Must be between 6 and 20 characters", MinimumLength = 6)]
        public string Password { get; set; }
        //==================================
        public  IFormFile? File { get; set; }  
        public string? PhotoPath { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
