using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerenaLiao_MVC.Models
{
    [Table("sjghel_patients")]
    public class Patients
    {
        [Key]
        public int Patient_Id { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please enter valid email.")]
        public string Patient_Email { get; set; }

        [Required(ErrorMessage = "Please set your password.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^[a-zA-Z0-9]{8,16}$", ErrorMessage = "Password cannot contain special characters and need to be 8-16 characters long.")]
        public string Patient_Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z]{1,25}$", ErrorMessage = "Please enter valid name.")]
        public string Patient_First_Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        [RegularExpression("^[a-zA-Z]{1,25}$", ErrorMessage = "Please enter valid name.")]
        public string Patient_Last_Name { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Patient_Date_Of_Birth { get; set; }

        [Required(ErrorMessage = "Please select your gender.")]
        [Display(Name = "Gender")]
        public string Patient_Gender { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Display(Name = "Phone Number")]
        [RegularExpression("^[0-9]{8,15}$", ErrorMessage = "Please enter valid phone number.")]
        public string Patient_Phone { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        [Display(Name = "Address")]
        public string Patient_Address { get; set; }

        [Required(ErrorMessage = "Please enter your postal code.")]
        [Display(Name = "Postal Code")]
        [RegularExpression("^[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]$", ErrorMessage = "Please enter valid postal code.")]
        public string Patient_PostCode { get; set; }
    }
}