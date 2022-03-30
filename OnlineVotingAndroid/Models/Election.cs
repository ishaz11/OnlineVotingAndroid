using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class Election
    {
        [Key]
        [Display(Name = "Election ID")]
        public int ElectionID { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Election")]
        public string ElectionName { get; set; }

        [Display(Name = "Set this as current active election")]
        public bool IsActive { get; set; } = false;
    }
}