using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Platform")]
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "The value cannot exceed 50 characters. ")]
        public string PlatformDescription { get; set; }

        public int? PartyListID { get; set; }
        [ForeignKey("PartyListID")]
        public virtual PartyList PartyLists { get; set; }



    }
}