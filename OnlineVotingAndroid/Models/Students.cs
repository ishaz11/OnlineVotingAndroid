using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Student ID")]
        public string StudentSchoolID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "Required")]
        public string YearnSection { get; set; }

        public bool isEnable { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase File1 { get; set; }
    }
}