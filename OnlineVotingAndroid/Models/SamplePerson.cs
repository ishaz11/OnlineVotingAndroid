﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class SamplePerson
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Student ID")]
        [Required(ErrorMessage = "Required")]
        public string StudentID { get; set; }

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

        [Display(Name = "Role")]
        public string Role { get; set; }

        public bool isEnable { get; set; }
    }
}